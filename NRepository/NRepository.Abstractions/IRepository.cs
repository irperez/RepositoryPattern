using NSpecifications;
using System;
using System.Collections.Generic;

namespace NRepository.Abstractions
{
    /// <summary>
    /// Generic repository, will probably live in another class library project that can be shared with many other repos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T: class
    {
        T GetSingle(ASpec<T> specification);
        List<T> Get(ASpec<T> specification);
        List<T> Get();
        void Add(T entity);
        void Save(T entity); //I'm thinking of removing this.  Not sure yet.
        void Remove(Guid id);
    }
}
