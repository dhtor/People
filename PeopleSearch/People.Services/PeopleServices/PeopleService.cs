using People.Common;
using People.Manager.Dtos;
using People.Manager.PeopleManagers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Services.PeopleServices
{
    public interface IPeopleService
    {
        Task<Response<IEnumerable<PersonListDto>>> GetPeople(RequestContext requestContext);
        Task<Response<IEnumerable<PersonListDto>>> SearchPeople(RequestContext requestContext, string param);
    }

    public class PeopleService : IPeopleService
    {
        protected IServiceExecuter ServiceExecuter;
        protected IPersonListManager PersonListManager;
        protected IPersonSearchManager PersonSearchManager;

        public PeopleService(IServiceExecuter serviceExecuter, IPersonListManager personListManager, IPersonSearchManager personSearchManager)
        {
            ServiceExecuter = serviceExecuter;
            PersonListManager = personListManager;
            PersonSearchManager = personSearchManager;
        }

        public async Task<Response<IEnumerable<PersonListDto>>> GetPeople(RequestContext requestContext)
        {
            return await ServiceExecuter.Execute(requestContext, PersonListManager.GetAll);
        }

        public async Task<Response<IEnumerable<PersonListDto>>> SearchPeople(RequestContext requestContext, string param)
        {
            return await ServiceExecuter.Execute(requestContext, PersonSearchManager.SearchPeople, param);
        }
    }
}
