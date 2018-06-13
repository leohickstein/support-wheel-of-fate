using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WheelOfFate.Domain.Entities;

namespace WheelOfFate.Data
{
    /// <summary>
    /// Not being used in this POC, but that's how I would implement in a full implementation
    /// </summary>
    public class BauApiContext : DbContext
    {
        public BauApiContext(DbContextOptions<BauApiContext> options)
            : base()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
    }
}
