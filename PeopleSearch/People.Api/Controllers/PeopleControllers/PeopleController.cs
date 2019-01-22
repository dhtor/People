using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using People.Services.PeopleServices;
using People.Api.Providers;
using People.Common;

namespace People.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : Controller
    {
        protected IPeopleService PeopleService;
        protected IRequestContextProvider RequestContextProvider;

        public PeopleController(IPeopleService peopleService, IRequestContextProvider requestContextProvider)
        {
            PeopleService = peopleService;
            RequestContextProvider = requestContextProvider;
        }

        //[HttpGet()]
        //public async Task<IActionResult> Get(CancellationToken ct)
        //{
        //    var result =  await PeopleService.GetPeople(RequestContextProvider.Get(ct));
        //    return Ok(result);
        //}

        [HttpGet()]
        public async Task<IActionResult> Get(string param, CancellationToken ct)
        {
            var result = await PeopleService.SearchPeople(RequestContextProvider.Get(ct), param);
            return Ok(result);
        }

    }

}
