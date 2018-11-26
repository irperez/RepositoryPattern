using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRepository.UniversityBL.BL;
using NRepository.UniversityBL.BL.DataAccess;
using NRepository.UniversityBL.Domain;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;

namespace UniversityBL.Tests
{
    [TestClass]
    public class CourseProvider_Tests
    {
        private Container Container { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            Container = new Container();
            Container.Register<ICourseRepository, CourseRepository>();
            Container.Register<CourseProvider>();
            Container.Register<DbContext, UniversityContext>();
            Container.Register<DbContextOptions<UniversityContext>>(() => {
                return new DbContextOptionsBuilder<UniversityContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;
            }, Lifestyle.Singleton);

            Registration registration = Container.GetRegistration(typeof(UniversityContext)).Registration;

            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                "Reason of suppression");

            Container.Verify();
        }

        [TestMethod]
        public void CourseProvider_CRUD_Test()
        {
            CourseProvider tp = Container.GetInstance<CourseProvider>();

            var mathCourse = new Course
            {
                Guid = Guid.NewGuid(),
                Name = "Math",
                AverageRating = 5,
                StartDate = new DateTimeOffset(2018, 10, 31, 8, 0, 0, new TimeSpan(0)),
            };

            var englishCourse = new Course
            {
                Guid = Guid.NewGuid(),
                Name = "English",
                AverageRating = 2,
                StartDate = new DateTimeOffset(2018, 8, 31, 8, 0, 0, new TimeSpan(0)),
            };

            var biologyCourse = new Course
            {
                Guid = Guid.NewGuid(),
                Name = "Biology",
                AverageRating = 4,
                StartDate = new DateTimeOffset(2018, 9, 30, 8, 0, 0, new TimeSpan(0)),
            };

            var mathValidation = tp.Add(mathCourse);
            var englishValidation = tp.Add(englishCourse);
            var biologyValidation = tp.Add(biologyCourse);

            var actual = tp.GetHighlyRatedCourses();

            Assert.IsNotNull(actual);
            Assert.AreEqual<int>(2, actual.Count);
            Assert.IsTrue(actual.Contains(mathCourse));

            var actual2 = tp.GetHistoricalCourses(new DateTimeOffset(2018, 10, 1, 0, 0, 0, new TimeSpan()), new DateTimeOffset(2018, 12, 1, 0, 0, 0, new TimeSpan()));

            Assert.IsNotNull(actual2);
            Assert.AreEqual<int>(1, actual2.Count);
            Assert.IsTrue(actual2.Contains(mathCourse));
        }
    }
}
