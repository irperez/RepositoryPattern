using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using eviti.data.tracking.Interfaces;
namespace EvitiContact.ApplicationService.RepositoryDB
{
    public interface IRepository<TEntity, PKType> where TEntity : class
    {
        TEntity Get(PKType id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void AttachOnly(IClientChangeTracker entity);
    }
}
