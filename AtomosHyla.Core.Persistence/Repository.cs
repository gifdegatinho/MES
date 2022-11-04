using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace AtomosHyla.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #region IRepository Members

        /// <summary>
        /// Adds the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity</param>
        /// <returns></returns>
        public virtual T Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return entity;
        }

        /// <summary>
        /// Adds the entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities</param>
        /// <returns></returns>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            if (entities.Any())
            {
                DbContext.Set<T>().AddRange(entities);
            }
        }

        /// <summary>
        /// Modify the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity</param>
        /// <returns></returns>
        public virtual T Modify(T entity)
        {
            if (!DbContext.Set<T>().Contains<T>(entity))
            {
                DbContext.Set<T>().Attach(entity);
            }
            DbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity</param>
        public virtual void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Deletes the entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">The entities</param>
        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            if (entities.Any())
            {
                DbContext.Set<T>().RemoveRange(entities);
            }
        }

        /// <summary>
        /// Detach the entity from the set
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns></returns>
        public virtual void DetachEntity(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Detached;
        }

        /// <summary>
        /// Gets the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> query)
        {
            return DbContext.Set<T>().Where(query);
        }

        /// <summary>
        /// Gets the entity
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns></returns>
        public virtual T Get(params object[] primaryKey)
        {
            return DbContext.Set<T>().Find(primaryKey);
        }
        
        /// <summary>
        /// Gets if the entity exists
        /// </summary>
        /// <param name="primaryKey">The primary key</param>
        /// <returns></returns>
        public virtual bool Exists(params object[] primaryKey)
        {
            return Get(primaryKey) != null;
        }

        /// <summary>
        /// Gets the unit of work
        /// </summary>
        /// <value>The unit of work</value>
        public IUnitOfWork UnitOfWork { get; private set; }

        #endregion

        /// <summary>
        /// Gets the DbContext
        /// </summary>
        /// <returns></returns>
        public DbContext DbContext
        {
            get
            {
                return (DbContext)UnitOfWork.Context;
            }
        }
    }
}
