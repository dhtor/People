import { Component, OnInit, ElementRef, ViewChild} from '@angular/core';
import { Observable } from 'rxjs';
import { of } from "rxjs";
import { map, switchMap, debounceTime, distinctUntilChanged, delay, share } from 'rxjs/operators';
import {  FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Person } from './models/person';
import { messageResponse } from '../../shared/models/messageResponse';

//services
import { PeopleService } from './people.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  providers: [PeopleService]
})

export class PeopleComponent {

  loading: boolean;
  hasSearched: boolean;
  simulateSlow: false;
  searchForm: FormGroup;
  results: Observable<Person[]>;

  constructor(private formBuilder: FormBuilder, private _service: PeopleService) {
    this.searchForm = this.formBuilder.group({
      search: ['', Validators.required]
    });
  }

  ngOnInit() {
  this.search();
  }

  search() {

    this.results = this.searchForm.controls.search.valueChanges.pipe(
      debounceTime(500),
      //filter(value => value.length > 3),
      distinctUntilChanged(),
      switchMap(searchTerm => {

        var delayTime = 0;
        if (this.simulateSlow)
          delayTime = 2500;

        let obsPeopleList = searchTerm ? this._service.searchPeople(searchTerm).pipe(delay(delayTime)) : of(new messageResponse<Person[]>());
        //this._service.searchPeople(searchTerm)

        if (this.simulateSlow)
          obsPeopleList.pipe(delay(5000));

        //obsPeopleList.subscribe(() => {
        //  this.loading = false;
        //  this.hasSearched = true;
        //});

        return obsPeopleList;
      }),
      map(messageResponse => {
        if (!messageResponse.result)
          return null;
        messageResponse.result.sort((a, b) => {
          if (a.firstName < b.firstName)
            return -1;
          if (a.firstName === b.firstName && a.lastName < b.lastName)
            return -1;

          return 1;
        });
        console.log(messageResponse);

        return messageResponse.result;
      }),
    share() );
  }

}

