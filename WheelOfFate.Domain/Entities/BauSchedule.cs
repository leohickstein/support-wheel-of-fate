using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    /// <summary>
    /// Represents a Schedule of BAU's for a single date in the problem domain
    /// </summary>
    public class BauSchedule
    {
        public BauSchedule(DateTime date)
        {
            Date = date;
            Baus = new List<Bau>();
        }

        public DateTime Date { get; private set; }
        public List<Bau> Baus { get; private set; }
    }
}
