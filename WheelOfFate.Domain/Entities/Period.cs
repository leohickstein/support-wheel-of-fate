using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    public class Period
    {
        public Period(DateTime startDate, DateTime endDate, bool includesWeekend)
        {
            StartDate = startDate;
            EndDate = endDate;
            IncludesWeekend = includesWeekend;

            if (IncludesWeekend)
                TotalDays = (int)endDate.Subtract(startDate).TotalDays;
            else
                TotalDays = GetBusinessDays2(startDate, endDate);
        }

        public int GetWorkingDays(DateTime from, DateTime to)
        {
            var dayDifference = (int)to.Subtract(from).TotalDays;
            return Enumerable
                .Range(1, dayDifference)
                .Select(x => from.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
        }

        public int GetBusinessDays2(DateTime startD, DateTime endD)
        {
            int calcBusinessDays = Convert.ToInt32(
                1 + ((endD - startD).TotalDays * 5 -
                (startD.DayOfWeek - endD.DayOfWeek) * 2) / 7);

            if (endD.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
            if (startD.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;

            return calcBusinessDays;
        }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IncludesWeekend { get; private set; }
        public int TotalDays { get; private set; }
    }
}
