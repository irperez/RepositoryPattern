using System;
using Microsoft.EntityFrameworkCore;
using NRepository.UniversityBL.BL;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using University.Data;

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
            container.Register<ICourseRepository, CourseRepository>(Lifestyle.Scoped);
            container.Register<CourseProvider>(Lifestyle.Scoped);
            container.Register<DbContext, UniversityContext>(Lifestyle.Scoped);
            container.Register<DbContextOptions<UniversityContext>>(() => {
                return new DbContextOptionsBuilder<UniversityContext>()
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
