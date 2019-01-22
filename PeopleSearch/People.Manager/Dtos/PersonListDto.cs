using System.Collections.Generic;

namespace People.Manager.Dtos
{
    public class PersonListDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public int? Age { get; set; }
        public AddressDto Address { get; set; }
        public IEnumerable<string> Interest { get; set; }

    }
}
