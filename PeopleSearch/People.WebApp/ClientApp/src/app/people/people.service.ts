import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';  

import { environment } from '../../environments/environment';
import { messageResponse } from '../../shared/models/messageResponse';
import { Person } from './models/person';
import { PeopleSearchParam } from './models/peopleSearchParam';
import { SearchResults } from './models/searchResults';

@Injectable()
export class PeopleService {

  constructor(private _httpc: HttpClient) { }

  searchPeople(searchTerm: string): Observable<messageResponse<Person[]>> {

    return this._httpc.get<messageResponse<Person[]>>(environment.peopleAPI + 'people', {
      params: {
        param: searchTerm
      }
    });
  }

}
