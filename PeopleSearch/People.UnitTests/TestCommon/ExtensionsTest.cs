using Microsoft.VisualStudio.TestTools.UnitTesting;
using People.Common.Extensions;
using System;

namespace People.UnitTests.TestCommon
{
    [TestClass]
    public class ExtensionsTest
    {
        [TestMethod]
        public void AgeExtension_DateIsNull_ShouldPass()
        {
            // Arrange
            DateTime? date = null;

            // Act
            var result = date.GetCurrentAge();

            // Assert
            Assert.IsNull(result);
        }
    }
}
