using System;
using System.Collections.Generic;
using System.Text;
using WheelOfFate.Domain.Entities;
using Xunit;

namespace WheelOfFate.Tests.Domain.Entities
{
    public class EmployeeTests
    {
        [Fact]
        public void ShouldNotHaveAssignedDateAfterCreated()
        {
            // Arrange
            var expectedLastAssignedDate = DateTime.MinValue;

            // Act
            var employee = new Employee(1, "Employee 1");
            var result = employee.LastAssignedDate;

            // Assert
            Assert.Equal(expectedLastAssignedDate, result);
        }

        [Fact]
        public void Should_return_employee_with_one_bauschedule_and_last_assigned_date()
        {
            // Arrange
            var employee = new Employee(1, "Employee 1");
            var expectedLastAssignedDate = DateTime.Now;
            var bauSchedule = new BauSchedule(expectedLastAssignedDate);

            // Act
            employee.AddSchedule(bauSchedule);
            var result = employee.LastAssignedDate;

            // Assert
            Assert.Equal(expectedLastAssignedDate, result);
        }
    }
}
