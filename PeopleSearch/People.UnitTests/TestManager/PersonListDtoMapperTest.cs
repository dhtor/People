using Microsoft.VisualStudio.TestTools.UnitTesting;
using People.DataLayer.Entities;
using People.Manager.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace People.UnitTests.TestManager
{
    [TestClass]
    public class PersonListDtoMapperTest
    {

        [TestMethod]
        public void Map_PersonsIsNull_ShouldPass()
        {
            // Arrange
            IQueryable<Person> persons = null;

            // Act
            var result = PersonListDtoMapper.Map(persons);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Map_DateOfBirthIsNull_ShouldPass()
        {
            // Arrange
            IQueryable<Person> persons = new List<Person>
                {
                    new Person { Id = 1, DateOfBirth = null },

                }.AsQueryable(); ;

            // Act
            var result = PersonListDtoMapper.Map(persons);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
