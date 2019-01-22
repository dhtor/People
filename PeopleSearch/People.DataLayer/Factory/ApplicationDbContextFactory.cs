using People.DataLayer.Context;

namespace People.DataLayer.Factory
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }

    public class ApplicationDbContextFactory : IApplicationDbContextFactory
    {
        private readonly ApplicationDbContextOptions options;

        public ApplicationDbContextFactory(ApplicationDbContextOptions options)
        {
            this.options = options;
        }

        public ApplicationDbContext Create()
        {
            return new ApplicationDbContext(options);
        }
    }
}
