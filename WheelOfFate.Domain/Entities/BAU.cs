using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    public class BAU
    {
        public BAU(Employee employee, Shift shift)
        {
            Employee = employee;
            Shift = shift;
        }

        public Employee Employee { get; set; }
        public Shift Shift { get; set; }
    }
}
