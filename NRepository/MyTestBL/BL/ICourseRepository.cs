using NRepository.Abstractions;
using NRepository.UniversityBL.Domain;
using NSpecifications;
using System;
using System.Collections.Generic;

namespace NRepository.UniversityBL.BL
{
    //A specific interface thats unique to the Test Repository's needs
    public interface ICourseRepository : IRepository<Course>
    {
        List<Guid> GetChildGuids(ASpec<Course> specification);
    }
}
