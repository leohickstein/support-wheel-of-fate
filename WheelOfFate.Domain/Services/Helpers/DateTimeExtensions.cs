using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFate.Domain.Services.Helpers
{
    public static class DateTimeExtensions
    {
        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday;
        }

        public static int GetTotalWorkingDays(this DateTime startDate, DateTime endDate, bool includeWeekend)
        {
            int calcBusinessDays;

            if (includeWeekend)
            {
                calcBusinessDays = Convert.ToInt32((endDate - startDate).TotalDays);
            }
            else
            {
                calcBusinessDays = Convert.ToInt32(
                    1 + ((endDate - startDate).TotalDays * 5 -
                    (startDate.DayOfWeek - endDate.DayOfWeek) * 2) / 7);

                if (endDate.DayOfWeek == DayOfWeek.Saturday) calcBusinessDays--;
                if (startDate.DayOfWeek == DayOfWeek.Sunday) calcBusinessDays--;
            }

            return calcBusinessDays;
        }
    }
}
