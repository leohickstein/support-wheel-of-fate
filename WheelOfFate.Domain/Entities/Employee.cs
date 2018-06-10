using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFate.Domain.Entities
{
    public class Employee
    {
        public Employee(int employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
            Schedules = new List<Schedule>();
        }

        public int EmployeeId { get; private set; }
        public string Name { get; private set; }
        public List<Schedule> Schedules { get; private set; }
        public DateTime LastAssignedDate { get; private set; }

        public void AddSchedule(Schedule schedule)
        {
            LastAssignedDate = schedule.Date;
            Schedules.Add(schedule);
        }
    }
}
