using System;
using System.Collections.Generic;
using System.Text;
using WheelOfFate.Domain.Entities;

namespace WheelOfFate.Domain.Interfaces
{
    public interface IBAUGenerator
    {
        List<Schedule> GenerateSchedule(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees);
    }
}
