using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NRepository.MyTestBL.BL;
using NRepository.MyTestBL.BL.DataAccess;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Lifestyles;

namespace NRepository.ConsoleFx
{
    public class Program
    {
        public static Container Container { get; set; }
        public static Listener Listener { get; set; }

        static void Main(string[] args)
        {
            Program.Bootstrap();

            Listener = new Listener();
            Listener.Container = Container;

            Listener.HandleMessage("Test Message");

            Console.ReadKey();
        }

        private static void Bootstrap()
        {
            // 1. Create a new Simple Injector container.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

            // 2. Configure the container (register)
            container.Register<ITestRepository, TestRepository>(Lifestyle.Scoped);
            container.Register<TestProvider>(Lifestyle.Scoped);
            container.Register<DbContext, MyTestContext>(Lifestyle.Scoped);
            container.Register<DbContextOptions<MyTestContext>>(() => {
                return new DbContextOptionsBuilder<MyTestContext>()
                .UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=True;")
                .Options;
            }, Lifestyle.Scoped);
            
            //Registration registration = container.GetRegistration(typeof(MyTestContext)).Registration;

            //registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Reason of suppression");

            // 3. Store the container for use by Page classes.
            Container = container;

            // 3. Verify the container's configuration.
            container.Verify();
        }
    }
}
