using Microsoft.EntityFrameworkCore;
using People.Common;
using People.DataLayer.Entities;
using People.DataLayer.Factory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.DataLayer.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll(RequestContext requestContext);
        Task<IEnumerable<Person>> Search(RequestContext requestContext, string term);
    }
    public class PersonRepository : IPersonRepository
    {
        private readonly IApplicationDbContextFactory dbContextFactory;

        public PersonRepository(IApplicationDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Person>> GetAll(RequestContext requestContext)
        {
            using (var context = dbContextFactory.Create())
            {
                return await context.Persons.ToListAsync(requestContext.CancelationToken);
            }
        }

        public async Task<IEnumerable<Person>> Search(RequestContext requestContext, string term)
        {
            using (var context = dbContextFactory.Create())
            {
                var query = context.Persons
                    .Include(p => p.Address)
                    .Include(p => p.Interests);
                if (string.IsNullOrEmpty(term))
                {
                    return await query.ToListAsync(requestContext.CancelationToken);
                }
                else
                {
                    return await query.Where(p => p.FirstName.ToLower().Contains(term.ToLower()) || p.LastName.ToLower().Contains(term.ToLower())).ToListAsync(requestContext.CancelationToken);
                }
            }
        }
    }
}
