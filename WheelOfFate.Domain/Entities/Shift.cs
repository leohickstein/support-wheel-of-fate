using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    /// <summary>
    /// Represents a Shift in the problem domain
    /// </summary>
    public class Shift
    {
        public Shift(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        [IgnoreDataMember] // Won't be returned in the result JSON
        public List<Employee> Employees { get; set; }
    }
}
