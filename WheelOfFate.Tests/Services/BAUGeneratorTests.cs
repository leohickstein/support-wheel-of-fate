using System;
using System.Collections.Generic;
using System.Diagnostics;
using WheelOfFate.Domain.Entities;
using Xunit;
using WheelOfFate.Domain.Interfaces.Services;
using WheelOfFate.Services;

namespace WheelOfFate.Tests.Services
{
    public class BauGeneratorTests
    {
        protected BauService ServiceUnderTest { get; }

        public BauGeneratorTests()
        {
            ServiceUnderTest = new BauService();
        }

        [Fact]
        public void ShouldGenerate10DailyShiftsWith2EmployeesEachFor10EmployeesAnd2ShiftsAnd2Weeks()
        {
            // Arrange
            DateTime startDate = new DateTime(2018, 6, 11);
            DateTime endDate = new DateTime(2018, 6, 22);
            int numberOfShifts = 2;
            int numberOfEmployees = 10;

            // Act
            var result = ServiceUnderTest.GenerateBauSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            // Assert
            Assert.Equal(10, result.Count);
            Assert.All(result, bauSchedule => Assert.Equal(2, bauSchedule.Baus.Count));
        }

        [Fact]
        public void ShouldGenerate10DailyShiftsWith3EmployeesEachFor10EmployeesAnd3ShiftsAnd2Weeks()
        {
            // Arrange
            DateTime startDate = new DateTime(2018, 6, 11);
            DateTime endDate = new DateTime(2018, 6, 22);
            int numberOfShifts = 3;
            int numberOfEmployees = 10;

            // Act
            var result = ServiceUnderTest.GenerateBauSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            // Assert
            Assert.Equal(10, result.Count);
            Assert.All(result, bauSchedule => Assert.Equal(3, bauSchedule.Baus.Count));
        }

        [Fact]
        public void ShouldGenerate5DailyShiftsWith2EmployeesEachFor10EmployeesAnd2ShiftsAnd7DaysWith2WeekendDays()
        {
            // Arrange
            DateTime startDate = new DateTime(2018, 6, 11);
            DateTime endDate = new DateTime(2018, 6, 17);
            int numberOfShifts = 2;
            int numberOfEmployees = 10;

            // Act
            var result = ServiceUnderTest.GenerateBauSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            // Assert
            Assert.Equal(5, result.Count);
            Assert.All(result, bauSchedule => Assert.Equal(2, bauSchedule.Baus.Count));
        }

        [Fact]
        public void ShouldGenerate1DailyShiftsWith3EmployeesEachFor3EmployeesAnd3ShiftsAnd1Days()
        {
            // Arrange
            DateTime startDate = new DateTime(2018, 6, 11);
            DateTime endDate = new DateTime(2018, 6, 11);
            int numberOfShifts = 3;
            int numberOfEmployees = 3;
            IBauService bauService = new BauService();

            // Act
            var result = ServiceUnderTest.GenerateBauSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            // Assert
            Assert.Single(result);
            Assert.All(result, bauSchedule => Assert.Equal(3, bauSchedule.Baus.Count));
        }
    }
}
