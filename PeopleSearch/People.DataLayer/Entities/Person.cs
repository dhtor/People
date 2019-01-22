using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.DataLayer.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }

        public Person() => Interests = new List<Interest>();

    }
}
