using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WheelOfFate.Domain.Services.Helpers;
using Xunit;

namespace WheelOfFate.Tests.Domain.Services
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void Should_return_true_if_is_working_day()
        {
            // Arrange
            DateTime weekDay = new DateTime(2018, 6, 11); // monday
            var expectedWorkingDay = (
                weekDay.DayOfWeek == DayOfWeek.Monday || 
                weekDay.DayOfWeek == DayOfWeek.Tuesday ||
                weekDay.DayOfWeek == DayOfWeek.Wednesday ||
                weekDay.DayOfWeek == DayOfWeek.Thursday ||
                weekDay.DayOfWeek == DayOfWeek.Friday);

            // Act
            var result = weekDay.IsWorkingDay();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Should_return_false_if_is_not_working_day()
        {
            // Arrange
            var weekendDay = new DateTime(2018, 6, 17); // sunday
            var expectedNotWorkingDay = (weekendDay.DayOfWeek == DayOfWeek.Saturday || weekendDay.DayOfWeek == DayOfWeek.Sunday);

            // Act
            var result = weekendDay.IsWorkingDay();

            // Assert
            Assert.False(result);
        }
    }
}