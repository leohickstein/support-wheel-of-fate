﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Services;
using WheelOfFate.Domain.Services.Helpers;

namespace WheelOfFate.Domain.Services
{
    /*
     * Business rules
        ·  An engineer can do at most one half day shift in a day
        ·  An engineer cannot have half day shifts on consecutive days
        ·  Each engineer should have completed one whole day of support in any 2 week period
     */
    public class DefaultBauGeneratorStrategy : IBauGeneratorStrategy
    {
        public List<BauSchedule> GenerateBauSchedules(DateTime startDate, DateTime endDate, int numberOfShifts, int numberOfEmployees)
        {

            List<Shift> shifts = EntityGenerator.GenerateShifts(numberOfShifts);
            List <Employee> employees = EntityGenerator.GenerateEmployees(numberOfEmployees);

            // Determine total slots available based on the period and number of shifts
            var numSlots = startDate.GetTotalWorkingDays(endDate, false) * numberOfShifts; //  Example: 20 slots = 2 slots by day * 10 days

            // Determine max number of employees allowed by shift
            var maxEmployeesByShift = Math.Ceiling(((double)numSlots) / ((double)numberOfEmployees)); // Example: 2 slots/employees = 20 slots / 10 employees

            List<BauSchedule> bauSchedule = new List<BauSchedule>();

            // Iterate through all days in the provided period
            for (DateTime currentDate = startDate; currentDate.Date <= endDate.Date; currentDate = currentDate.AddDays(1))
            {
                // BUSINESS RULE: only consider weekdays
                if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                BauSchedule currentSchedule = new BauSchedule(currentDate);

                // Iterate through all shifts
                foreach (var currentShift in shifts)
                {
                    // choose randomly a employee which haven't filled all slots yet
                    var randomEmployee = employees
                        .Where(e => e.Schedules.Count < maxEmployeesByShift)
                        // BUSINESS RULE: An engineer can do at most one half day shift in a day
                        .Where(e => e.Schedules.LastOrDefault() == null || e.Schedules.LastOrDefault().Date != currentDate.Date)
                        // BUSINESS RULE: An engineer cannot have half day shifts on consecutive days
                        .Where(e => e.Schedules.LastOrDefault() == null || e.Schedules.LastOrDefault().Date != new DateTime(currentDate.Year, currentDate.Month, currentDate.Day).AddDays(-1).Date)
                        // Enforce a full cycle of employees
                        .Where(e => e.Schedules.Count <= employees.Min(min => min.Schedules.Count))
                        // BUSINESS RULE: This should select engineers at random
                        .OrderBy(random => Guid.NewGuid()).FirstOrDefault();

                    if (randomEmployee != null)
                    {
                        // Using DDD to modify a domain entity
                        randomEmployee.AddSchedule(new BauSchedule(currentDate));
                        currentSchedule.Baus.Add(new Bau(randomEmployee, currentShift));
                    }
                }
                bauSchedule.Add(currentSchedule);
            }
            return bauSchedule;
        }
    }
}
