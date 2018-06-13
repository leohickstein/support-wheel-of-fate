using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    /// <summary>
    /// Represents a Employee in the problem domain
    /// </summary>
    public class Employee
    {
        public Employee(int employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
            Schedules = new List<BauSchedule>();
        }

        public int EmployeeId { get; private set; }
        public string Name { get; private set; }
        [IgnoreDataMember] // Won't be returned in the result JSON
        public List<BauSchedule> Schedules { get; private set; }
        [IgnoreDataMember] // Won't be returned in the result JSON
        public DateTime LastAssignedDate { get; private set; }

        public void AddSchedule(BauSchedule schedule)
        {
            LastAssignedDate = schedule.Date;
            Schedules.Add(schedule);
        }
    }
}
