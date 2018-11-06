using NRepository.MyTestBL.Models;
using System;
using System.Collections.Generic;

namespace NRepository.MyTestBL.BL
{
    //NSpecifications nuget package can be found here: https://www.nuget.org/packages/NSpecifications
    //Github: https://github.com/jnicolau/NSpecifications
    //Unit of Work/Repository Concepts: https://medium.com/@utterbbq/c-unitofwork-and-repository-pattern-305cd8ecfa7a
    public class TestProvider
    {
        public ITestRepository TestRepo { get; set; }

        public TestProvider(ITestRepository repository) //Do not create another constructor
        {
            TestRepo = repository;
        }

        public List<Guid> GetHistoricalItemGuids()
        {
            return TestRepo.GetChildGuids(TestSpecs.PassingScoreSpec(85));
        }

        public List<Test> GetPassingTests()
        {
            return TestRepo.Get(TestSpecs.PassingScoreSpec(70));
        }

        public List<Test> GetHistoricalTests(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return TestRepo.Get(TestSpecs.TimeFrame(startDate, endDate));
        }

        public List<Test> GetPassingHistoricalTests(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            //Here we are combining preexisting specs using "AND" logic.
            return TestRepo.Get(TestSpecs.TimeFrame(startDate, endDate) & TestSpecs.PassingScoreSpec(70));
        }

        public void Add(Test instance)
        {
            TestRepo.Add(instance);
        }

        public void Update(Test instance)
        {
            TestRepo.Save(instance);
        }
    }
}
