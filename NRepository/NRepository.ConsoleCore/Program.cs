using System;
using Microsoft.EntityFrameworkCore;
using NRepository.UniversityBL.BL;
using NRepository.UniversityBL.BL.DataAccess;
using SimpleInjector;
using SimpleInjector.Diagnostics;

namespace NRepository.ConsoleCore
{
    class Program
    {
        public static Container Container { get; set; }

        static void Main(string[] args)
        {
            Program.Bootstrap();

            var testProvider = Container.GetInstance<CourseProvider>();

            var data = testProvider.GetHighlyRatedCourses();

            Console.WriteLine("Test Provider loaded successfully");

            Console.ReadKey();
        }

        private static void Bootstrap()
        {
            // 1. Create a new Simple Injector container.
            var container = new Container();

            // 2. Configure the container (register)
            container.Register<ICourseRepository, CourseRepository>();
            container.Register<CourseProvider>();
            container.Register<DbContext, UniversityContext>();
            container.Register<DbContextOptions<UniversityContext>>(() => {
                return new DbContextOptionsBuilder<UniversityContext>()
                .UseSqlServer("Server=localhost;Database=TestDB;Trusted_Connection=True;")
                .Options;
            }, Lifestyle.Singleton);

            Registration registration = container.GetRegistration(typeof(UniversityContext)).Registration;

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Reason of suppression");

            // 3. Store the container for use by Page classes.
            Container = container;

            // 3. Verify the container's configuration.
            container.Verify();
        }
    }
}
