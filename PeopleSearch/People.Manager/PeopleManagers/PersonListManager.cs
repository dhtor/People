using People.Common;
using People.DataLayer.Repositories;
using People.Manager.Dtos;
using People.Manager.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Manager.PeopleManagers
{
    public interface IPersonListManager
    {
        Task<IEnumerable<PersonListDto>> GetAll(RequestContext requestContext);
    }
    public class PersonListManager : IPersonListManager
    {
        private readonly IPersonRepository PersonRepository;

        public PersonListManager(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        public async Task<IEnumerable<PersonListDto>> GetAll(RequestContext requestContext)
        {
            var personList = await PersonRepository.GetAll(requestContext);
            return PersonListDtoMapper.Map(personList);
        }

    }
}
