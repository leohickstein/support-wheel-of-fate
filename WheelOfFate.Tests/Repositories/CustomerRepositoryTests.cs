using System;
using System.Collections.Generic;
using System.Text;
using WheelOfFate.Data.Repositories;
using Xunit;

namespace WheelOfFate.Tests.Repositories
{
    public class CustomerRepositoryTests
    {
        protected CustomerRepository RepositoryUnderTest { get; }

        public CustomerRepositoryTests()
        {
            RepositoryUnderTest = new CustomerRepository();
        }

        [Fact]
        public void Should_throw_a_NotImplementedException_when_Add_called()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<NotImplementedException>(() => RepositoryUnderTest.Add(null));
        }

        [Fact]
        public void Should_throw_a_NotImplementedException_when_All_called()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<NotImplementedException>(() => RepositoryUnderTest.All());
        }

        [Fact]
        public void Should_throw_a_NotImplementedException_when_Delete_called()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<NotImplementedException>(() => RepositoryUnderTest.Delete(null));
        }

        [Fact]
        public void Should_throw_a_NotImplementedException_when_Find_called()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<NotImplementedException>(() => RepositoryUnderTest.Find(null));
        }

        [Fact]
        public void Should_throw_a_NotImplementedException_when_Get_called()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<NotImplementedException>(() => RepositoryUnderTest.Get(0));
        }

        [Fact]
        public void Should_throw_a_NotImplementedException_when_Update_called()
        {
            // Arrange, Act, Assert
            var exception = Assert.Throws<NotImplementedException>(() => RepositoryUnderTest.Update(null));
        }
    }
}
