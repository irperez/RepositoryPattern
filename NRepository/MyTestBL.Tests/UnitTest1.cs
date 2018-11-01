using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRepository.MyTestBL.BL;
using NRepository.MyTestBL.BL.DataAccess;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Lifestyles;

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

            var actual = tp.GetPassingTests();

        }
    }
}
