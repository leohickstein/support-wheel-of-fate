using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Service;
using WheelOfFate.Services;

namespace WheelOfFate.Tests.Services
{
    [TestClass]
    public class BAUGeneratorTests
    {
        [TestMethod]
        public void ShouldGenerate10DailyShiftsWith2EmployeesEachFor10EmployeesAnd2ShiftsAnd2Weeks()
        {
            // Arrange
            DateTime startDate = new DateTime(2018, 6, 11);
            DateTime endDate = new DateTime(2018, 6, 22);
            int numberOfShifts = 2;
            int numberOfEmployees = 10;
            IBAUService BAUService = new BAUService();

            // Act
            List<Schedule> schedules = BAUService.GenerateBAUSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            foreach (var schedule in schedules)
            {
                Debug.WriteLine($"Schedule: {schedule.Date.ToString()}");

                foreach (var bau in schedule.BAUs)
                {
                    Debug.WriteLine($"Shift: {bau.Shift.Name}, Employee: {bau.Employee.Name}");
                }
            }

            // Assert
            Assert.AreEqual(10, schedules.Count);
        }

        [TestMethod]
        public void ShouldGenerate5DailyShiftsWith2EmployeesEachFor10EmployeesAnd2ShiftsAnd7DaysWith2WeekendDays()
        {
            // Arrange
            DateTime startDate = new DateTime(2018, 6, 11);
            DateTime endDate = new DateTime(2018, 6, 17);
            int numberOfShifts = 2;
            int numberOfEmployees = 10;
            IBAUService BAUService = new BAUService();

            // Act
            List<Schedule> schedules = BAUService.GenerateBAUSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            foreach (var schedule in schedules)
            {
                Debug.WriteLine($"Schedule: {schedule.Date.ToString()}");

                foreach (var bau in schedule.BAUs)
                {
                    Debug.WriteLine($"Shift: {bau.Shift.Name}, Employee: {bau.Employee.Name}");
                }
            }

            // Assert
            Assert.AreEqual(5, schedules.Count);
        }

        [TestMethod]
        public void ShouldGenerate1DailyShiftsWith3EmployeesEachFor3EmployeesAnd3ShiftsAnd1Days()
        {
            // Arrange
            DateTime startDate = new DateTime(2018, 6, 11);
            DateTime endDate = new DateTime(2018, 6, 11);
            int numberOfShifts = 3;
            int numberOfEmployees = 3;
            IBAUService BAUService = new BAUService();

            // Act
            List<Schedule> schedules = BAUService.GenerateBAUSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);

            foreach (var schedule in schedules)
            {
                Debug.WriteLine($"Schedule: {schedule.Date.ToString()}");

                foreach (var bau in schedule.BAUs)
                {
                    Debug.WriteLine($"Shift: {bau.Shift.Name}, Employee: {bau.Employee.Name}");
                }
            }

            // Assert
            Assert.AreEqual(1, schedules.Count);
            Assert.AreEqual(3, schedules[0].BAUs.Count);
        }
    }
}
