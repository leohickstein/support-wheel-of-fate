using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    public class Shift
    {
        public Shift(string name)
        {
            Name = name;
        }

        public int ShiftId { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
