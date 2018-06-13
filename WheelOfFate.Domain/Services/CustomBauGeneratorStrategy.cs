using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Services;

namespace WheelOfFate.Domain.Services
{
    public class CustomBauGeneratorStrategy : IBauGeneratorStrategy
    {
        public List<BauSchedule> GenerateBauSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees)
        {
            throw new NotImplementedException();
        }
    }
}
