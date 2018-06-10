using System;
using System.Collections.Generic;
using System.Text;
using WheelOfFate.Domain.Entities;

namespace WheelOfFate.Domain.Services.Helpers
{
    public class EntityGenerator
    {
        public static List<Employee> GenerateEmployees(int quantity)
        {
            var employees = new List<Employee>();

            for (int i = 1; i <= quantity; i++)
                employees.Add(new Employee(i, $"Employee {i}"));

            return employees;
        }

        public static List<Shift> GenerateShifts(int quantity)
        {
            var shifts = new List<Shift>();

            if (quantity == 2)
            {
                shifts.Add(new Shift("Morning (8am-12am)"));
                shifts.Add(new Shift("Afternoon (1pm-4pm)"));
            }
            else if (quantity == 3)
            {
                shifts.Add(new Shift("Morning (8am-12am)"));
                shifts.Add(new Shift("Afternoon (1pm-4pm)"));
                shifts.Add(new Shift("Night (5pm-9pm)"));
            }
            else
            {
                for (int i = 1; i <= quantity; i++)
                    shifts.Add(new Shift($"Shift {i}"));
            }

            return shifts;
        }
    }
}
