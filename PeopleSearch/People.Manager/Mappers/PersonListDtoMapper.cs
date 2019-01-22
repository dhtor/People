using People.Common.Extensions;
using People.DataLayer.Entities;
using People.Manager.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace People.Manager.Mappers
{
    public static class PersonListDtoMapper
    {
        public static PersonListDto Map(Person source)
        {
            if (source == null)
                return null;

            return new PersonListDto
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Age = source.DateOfBirth.GetCurrentAge(),
                PhotoUrl = source.PhotoUrl,
                Address = AddessDtoMapper.Map(source),
                Interest = source.Interests.Select(i => i.Description).ToList()
            };
        }

        public static IEnumerable<PersonListDto> Map(IEnumerable<Person> source)
        {
            if (source == null)
                return null;

            return source.Select(x => Map(x));
        }
    }
}
