using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Services;
using WheelOfFate.Domain.Services;

namespace WheelOfFate.Services
{
    public class BauService : IBauService
    {
        public BauService() { }

        /// <summary>
        /// Retrieve available strategies for generating a BAU Schedule
        /// </summary>
        /// <returns>List of available strategies</returns>
        public List<string> GetBauScheduleStrategies()
        {
            return BauGeneratorService.GetStrategies();
        }

        /// <summary>
        /// Generate the BAU Schedule
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="numberOfShifts">Number of shifts</param>
        /// <param name="numberOfEmployees">Number of employees</param>
        /// <returns>List of BAU schedules</returns>
        public List<BauSchedule> GenerateBauSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees)
        {
            BauGeneratorService generator = new BauGeneratorService(new DefaultBauGeneratorStrategy());
            return generator.GenerateBauSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);
        }
    }
}
