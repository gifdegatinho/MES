using System;
using System.Collections.Generic;

namespace AtomosHyla.Core
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        T Modify(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        bool Exists(params object[] primaryKey);
        void DetachEntity(T entity);
        T Get(params object[] primaryKey);
        System.Linq.IQueryable<T> GetAll();
        System.Linq.IQueryable<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> query);
        IUnitOfWork UnitOfWork { get; }
    }
}
