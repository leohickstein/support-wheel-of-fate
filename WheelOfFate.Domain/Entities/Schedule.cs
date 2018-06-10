using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    public class Schedule
    {
        public Schedule(DateTime date)
        {
            Date = date;
            BAUs = new List<BAU>(); // TODO: arrumar isso
        }

        public DateTime Date { get; set; }
        public List<BAU> BAUs { get; set; }
    }
}
