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
    public class ShiftRepository : IRepository<Shift>
    {
        public void Add(Shift entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shift> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(Shift entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shift> Find(Expression<Func<Shift, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Shift Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Shift entity)
        {
            throw new NotImplementedException();
        }
    }
}
