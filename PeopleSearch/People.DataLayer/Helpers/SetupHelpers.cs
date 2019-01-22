using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using People.DataLayer.Entities;
using People.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace People.DataLayer.Context
{
    public static class SetupHelpers
    {
        public static void EnsureCreated(this ApplicationDbContext db)
        {
            db.Database.EnsureCreated();
        }

        public static int SeedDatabase(this ApplicationDbContext context)
        {
            if (!(context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                throw new InvalidOperationException("The database does not exist. If you are using Migrations then run PMC command update-database to create it");

            

            var numPersons = context.Persons.Count();
            if (numPersons == 0)
            {


                var random = new Random();

                var firstArr = new string[] { "Angel", "Martin", "Fred", "George", "Richard", "Pedro", "Vick", "Brandon", "Caleb", "Simon" };
                var lastArr = new string[] { "McKane", "James", "Anderson", "Larsen", "Williams", "Frank", "Roberts", "Mitchell", "Sandoval", "Marks" };
                var streetArr = new string[] { "Furgeson Ave", "Main St", "Lightnening Peak Dr", "Clover Lane", "Fort Union Blvd", "Henderson Lane", "Fork Rd" };
                var cityArr = new string[] { "Mount Pleasant", "Crane City", "Frankford", "Flag Staff", "Flat Hills", "Gotham" };
                var stateArr = Enum.GetValues(typeof(States)).OfType<States>().ToArray();
                var postalCodeArr = new string[] { "84084", "84111", "64815", "89015", "84095", "90210", "95815" };
                var interestArr = new string[] { "Fly Fishing", "Hunting", "Hicking", "Gaming", "Walking the dog", "Painting", "Traveling", "Playing Piano", "Horses", "Trucks", "Food" };

                var addressList = new List<Address>();
                for (int i = 0; i < 7; i++)
                {
                    addressList.Add(new Address
                    {
                        StreetAddress = random.Next(155, 999).ToString() + " " + streetArr[random.Next(0, streetArr.Length)],
                        City = cityArr[random.Next(0, cityArr.Length)],
                        State = stateArr[random.Next(0, stateArr.Length)].ToString(),
                        PostalCode = postalCodeArr[random.Next(0, postalCodeArr.Length)]
                    });
                }

                var people = new List<Person>();
                var photoList = new List<int>();
                var uniquePhotoNum = 1;

                for (int i = 0; i < 25; i++)
                {
                    var interestIds = new List<int>();
                    var nextId = random.Next(0, interestArr.Length);
                    do
                    {
                        interestIds.Add(nextId);
                        nextId = random.Next(0, interestArr.Length);
                    } while (!interestIds.Contains(nextId));

                    people.Add(new Person
                    {
                        FirstName = firstArr[random.Next(0, firstArr.Length)],
                        LastName = lastArr[random.Next(0, lastArr.Length)],
                        DateOfBirth = new DateTime(random.Next(1975, 1997), random.Next(1, 13), random.Next(1, 28)),
                        PhotoUrl = $"/assets/userPhotos/{random.Next(0, 28)}.jpg",
                        Address = addressList[random.Next(0, addressList.Count)],
                        Interests = interestIds.Select(interestId => new Interest
                        {
                            Description = interestArr[interestId]
                        }).ToList()
                    });
                }

                context.Persons.AddRange(people);
                context.SaveChanges();

            }

            return numPersons;
        }
    }
}
