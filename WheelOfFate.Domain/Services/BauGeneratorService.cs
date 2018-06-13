using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Services;

namespace WheelOfFate.Domain.Services
{
    public class BauGeneratorService
    {
        private readonly IBauGeneratorStrategy _bauGeneratorStrategy;

        public BauGeneratorService(IBauGeneratorStrategy bauGeneratorStrategy) // Injection of IBauGeneratorStrategy
        {
            _bauGeneratorStrategy = bauGeneratorStrategy;
        }

        public List<BauSchedule> GenerateBauSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees)
        {
            return _bauGeneratorStrategy.GenerateBauSchedules(startDate, endDate, numberOfShifts, numberOfEmployees);
        }

        public static List<string> GetStrategies()
        {
            var results = (from type in Assembly.GetExecutingAssembly().GetTypes()
                           where typeof(IBauGeneratorStrategy).IsAssignableFrom(type) && type.IsClass
                           select type.Name).ToList();
            return results.ToList();
        }
    }
}
