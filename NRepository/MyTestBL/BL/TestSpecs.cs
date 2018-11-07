using NRepository.MyTestBL.Domain;
using NSpecifications;
using System;

namespace NRepository.MyTestBL.BL
{
    public static class TestSpecs
    {
        //Let's define our specs in the provider
        public static Spec<Test> PassingScoreSpec(int passingScore)
        {
            return new Spec<Test>(t => t.Score >= passingScore);
        }

        public static Spec<Test> TimeFrame(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return new Spec<Test>(t => t.TestDate >= startDate && t.TestDate <= endDate);
        }

        public static Spec<Test> ById(Guid guid)
        {
            return new Spec<Test>(t => t.Guid == guid);
        }
    }
}
