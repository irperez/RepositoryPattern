using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NRepository.Abstractions;
using NSpecifications;

namespace NRepository.EF
{
    class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T: class
    {
        public ReadOnlyRepository(DbContext context)
        {
            Context = context;
        }

        protected DbContext Context { get; set; }        

        public T GetSingle(ASpec<T> specification)
        {
            return Context.Set<T>().Where(specification).AsNoTracking().SingleOrDefault();
        }

        public List<T> Get(ASpec<T> specification)
        {
            return Context.Set<T>().Where(specification).AsNoTracking().ToList();
        }

        public List<T> Get()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }
    }    
}
