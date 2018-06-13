using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Services;
using WheelOfFate.Domain.Services.Helpers;
using WheelOfFate.Services;

namespace WheelOfFate.Tests.Domain.Services
{
    public class EntityGeneratorTests
    {
        [Fact]
        public void Should_return_10_Employees_not_null()
        {
            // Arrange

            // Act
            var result = EntityGenerator.GenerateEmployees(10);

            // Assert
            Assert.Equal(10, result.Count);
            Assert.All(result, employee => Assert.NotNull(employee));
        }

        [Fact]
        public void Should_return_3_Employees_with_Id_And_Name()
        {
            // Arrange

            // Act
            var result = EntityGenerator.GenerateEmployees(3);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.All(result, employee => Assert.NotEqual(0, employee.EmployeeId));
            Assert.All(result, employee => Assert.NotNull(employee.Name));
        }

        [Fact]
        public void Should_return_3_Shifts_with_Name()
        {
            // Arrange

            // Act
            var result = EntityGenerator.GenerateShifts(3);

            // Assert
            Assert.Equal(3, result.Count);
            Assert.All(result, shift => Assert.NotNull(shift.Name));
        }

        [Fact]
        public void Should_return_5_Shifts_not_null()
        {
            // Arrange

            // Act
            var result = EntityGenerator.GenerateShifts(5);

            // Assert
            Assert.Equal(5, result.Count);
            Assert.All(result, shift => Assert.NotNull(shift));
        }
    }
}
