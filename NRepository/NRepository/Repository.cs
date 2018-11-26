using NRepository.Abstractions;
using Microsoft.EntityFrameworkCore;
using NSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NRepository.EF
{
    /// <summary>
    /// Generic repository, will probably live in another class library project that can be shared with many other repos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T: class
    {
        public Repository(DbContext context) //Do not create another constructor
        {
            Context = context;
        }

        protected DbContext Context { get; set; }

        public void Add(T entity)
        {
            //NOTE: The lack of a using statement here
            Context.Add(entity);
            Context.SaveChanges();
        }

        public T GetSingle(ASpec<T> specification)
        {
            //NOTE: The lack of a using statement here
            return Context.Set<T>().Where(specification).SingleOrDefault();
        }

        public List<T> Get(ASpec<T> specification)
        {
            //NOTE: The lack of a using statement here
            return Context.Set<T>().Where(specification).ToList();
        }

        public List<T> Get()
        {
            //NOTE: The lack of a using statement here
            return Context.Set<T>().ToList();
        }

        public void Save(T entity) //I'm thinking of removing this, not sure yet.
        {
            //NOTE: The lack of a using statement here
            Context.SaveChanges();
        }
    }
}
