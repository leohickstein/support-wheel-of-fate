using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WheelOfFate.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Not being used in this POC, but that's how I would implement through repository pattern
    /// </summary>
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
