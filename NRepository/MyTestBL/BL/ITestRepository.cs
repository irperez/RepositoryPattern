using NRepository.Abstractions;
using NRepository.MyTestBL.Domain;
using NSpecifications;
using System;
using System.Collections.Generic;

namespace NRepository.MyTestBL.BL
{
    //A specific interface thats unique to the Test Repository's needs
    public interface ITestRepository : IRepository<Test>
    {
        List<Guid> GetChildGuids(ASpec<Test> specification);
    }
}
