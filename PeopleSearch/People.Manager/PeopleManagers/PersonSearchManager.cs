using People.Common;
using People.DataLayer.Repositories;
using People.Manager.Dtos;
using People.Manager.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Manager.PeopleManagers
{
    public interface IPersonSearchManager
    {
        Task<IEnumerable<PersonListDto>> SearchPeople(RequestContext requestContext, string param);
    }

    public class PersonSearchManager : IPersonSearchManager
    {
        private readonly IPersonRepository PersonRepository;

        public PersonSearchManager(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public async Task<IEnumerable<PersonListDto>> SearchPeople(RequestContext requestContext, string param)
        {
            if (string.IsNullOrEmpty(param))
                return null;

            var personList = await PersonRepository.Search(requestContext, param);
            return PersonListDtoMapper.Map(personList);

        }
    }
}
