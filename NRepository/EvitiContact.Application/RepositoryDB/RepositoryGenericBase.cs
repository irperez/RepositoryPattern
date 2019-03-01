using eviti.data.tracking.DataContactBase;
using eviti.data.tracking.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EvitiContact.Service.RepositoryDB
{
    //public class RepositoryOfInt<TEntity> : Repository<TEntity,int>, IRepository<TEntity, int> where TEntity : class
    //{


    //}


    public class Repository<TEntity, PKType> : IRepository<TEntity, PKType> where TEntity : class
    {
        protected readonly EvitiDBContactBase Context;
        private DbSet<TEntity> _entities;
        public Repository(EvitiDBContactBase context)
        {
            Context = context;

            _entities = Context.Set<TEntity>();
        }

        public TEntity Get(PKType id) // OR public TEntity Get(object id)
        {
            // Here we are working with a DbContext, not MyDBContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return _entities.Find(id);
            //return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return _entities.ToList();
            // return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void AttachOnly(IClientChangeTracker entity)
        {
            Context.AttachOnly(entity);
        }
       
    }



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
