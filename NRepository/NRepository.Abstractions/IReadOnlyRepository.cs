using NSpecifications;
using System.Collections.Generic;

namespace NRepository.Abstractions
{
    public interface IReadOnlyRepository<T> where T : class
    {
        T GetSingle(ASpec<T> specification);
        List<T> Get(ASpec<T> specification);
        List<T> Get();
    }
}
