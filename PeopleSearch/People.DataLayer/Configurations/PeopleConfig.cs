using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using People.DataLayer.Entities;

namespace People.DataLayer.Configurations
{
    public class PeopleConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> entity)
        {
            entity.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            entity
                .Property(x => x.FirstName)
                .HasColumnName("FirstName");

            entity
                .HasIndex(x => x.FirstName);
            entity
                .HasIndex(x => x.LastName);
        }
    }
}
