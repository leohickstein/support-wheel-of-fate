using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WheelOfFate.Domain;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces;
using WheelOfFate.Domain.Interfaces.Service;

namespace WheelOfFate.Services
{
    public class BAUService : IBAUService
    {
        // TODO: INjetar memoryDateConext

        public BAUService()
        {

        }

        public List<Schedule> GenerateBAUSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees)
        {
            IBAUGenerator schedule = new Flexible8x5BAUGenerator();
            return schedule.GenerateSchedule(startDate, endDate, numberOfShifts, numberOfEmployees);
        }

        //public static List<string> GetBAUScheduleAlgorithms()
        //{
        //    var results = from type in someAssembly.GetTypes()
        //                  where typeof(IFoo).IsAssignableFrom(type)
        //                  select type;

        //    return new List<string>();
        //}
    }
}
