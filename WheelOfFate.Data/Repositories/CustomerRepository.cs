using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WheelOfFate.Domain.Entities;
using WheelOfFate.Domain.Interfaces.Repositories;

namespace WheelOfFate.Data.Repositories
{
    /// <summary>
    /// Not being used in this POC, but that's how I would implement through repository pattern
    /// </summary>
    public class CustomerRepository : IRepository<Employee>
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
