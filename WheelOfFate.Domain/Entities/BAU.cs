using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    /// <summary>
    /// Represents a BAU in the problem domain
    /// </summary>
    public class Bau
    {
        public Bau(Employee employee, Shift shift)
        {
            Employee = employee;
            Shift = shift;
        }

        public Employee Employee { get; private set; }
        public Shift Shift { get; private set; }
    }
}
