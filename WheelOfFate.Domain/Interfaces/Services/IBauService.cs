using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WheelOfFate.Domain.Entities;

namespace WheelOfFate.Domain.Interfaces.Services
{
    public interface IBauService
    {
        List<string> GetBauScheduleStrategies();
        List<BauSchedule> GenerateBauSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees);
    }
}
