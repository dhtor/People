using Microsoft.EntityFrameworkCore;
using People.DataLayer.Configurations;
using People.DataLayer.Entities;

namespace People.DataLayer.Context
{
    public class ApplicationDbContextOptions
    {
        public readonly DbContextOptions<ApplicationDbContext> Options;

        public ApplicationDbContextOptions(DbContextOptions<ApplicationDbContext> options)
        {
            Options = options;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        private readonly ApplicationDbContextOptions options;

        public DbSet<Person> Persons { get; set; }

        public ApplicationDbContext(ApplicationDbContextOptions options)
            : base(options.Options)
        {
            this.options = options;
        }

        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleConfig());
        }
    }
}
