using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRepository.MyTestBL.BL;
using NRepository.MyTestBL.BL.DataAccess;
using NRepository.MyTestBL.Models;
using SimpleInjector;
using SimpleInjector.Diagnostics;

namespace MyTestBL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Container Container { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            Container = new Container();
            //Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Container.Register<ITestRepository, TestRepository>();
            Container.Register<TestProvider>();
            Container.Register<DbContext, MyTestContext>();
            Container.Register<DbContextOptions<MyTestContext>>(() => {
                return new DbContextOptionsBuilder<MyTestContext>()
                .UseInMemoryDatabase(databaseName: "Tests")
                .Options;
            }, Lifestyle.Singleton);

            Registration registration = Container.GetRegistration(typeof(MyTestContext)).Registration;

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "Reason of suppression");

            Container.Verify();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var tp = Container.GetInstance<TestProvider>();

            var myTest = new Test
            {
                Guid = Guid.NewGuid(),
                Name = "Test 1",
                Score = 90,
                TestDate = new DateTimeOffset(2018, 10, 31, 8, 0, 0, new TimeSpan(0)),
            };

            var myTest2 = new Test
            {
                Guid = Guid.NewGuid(),
                Name = "Test 2",
                Score = 50,
                TestDate = new DateTimeOffset(2018, 8, 31, 8, 0, 0, new TimeSpan(0)),
            };

            var myTest3 = new Test
            {
                Guid = Guid.NewGuid(),
                Name = "Test 3",
                Score = 80,
                TestDate = new DateTimeOffset(2018, 9, 30, 8, 0, 0, new TimeSpan(0)),
            };

            tp.Add(myTest);
            tp.Add(myTest2);
            tp.Add(myTest3);

            var actual = tp.GetPassingTests();

            Assert.IsNotNull(actual);
            Assert.AreEqual<int>(2, actual.Count);
            Assert.IsTrue(actual.Contains(myTest));

            var actual2 = tp.GetHistoricalTests(new DateTimeOffset(2018, 10, 1, 0, 0, 0, new TimeSpan()), new DateTimeOffset(2018, 12, 1, 0, 0, 0, new TimeSpan()));

            Assert.IsNotNull(actual2);
            Assert.AreEqual<int>(1, actual2.Count);
            Assert.IsTrue(actual2.Contains(myTest));
        }
    }
}
