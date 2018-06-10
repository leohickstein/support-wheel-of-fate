using System;
using System.Collections.Generic;
using System.Text;
using WheelOfFate.Domain.Entities;

namespace WheelOfFate.Domain.Interfaces.Service
{
    public interface IBAUService
    {
        List<Schedule> GenerateBAUSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees);
    }
}
