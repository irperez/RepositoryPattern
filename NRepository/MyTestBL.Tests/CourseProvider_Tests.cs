using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRepository.UniversityBL.BL;
using NRepository.UniversityBL.Domain;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using University.Data;

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

        [DataTestMethod]
        [DataRow("", "Please specify a course name.")]
        [DataRow("M", "The length of 'Name' must be at least 4 characters. You entered 1 characters.")]
        [DataRow("Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel", "The length of 'Name' must be 1024 characters or fewer. You entered 1025 characters.")]
        public void CourseProvider_NameValidation_Test(string name, string expectedValidationMessage)
        {
            CourseProvider tp = Container.GetInstance<CourseProvider>();

            var mathCourse = new Course
            {
                Guid = Guid.NewGuid(),
                Name = name,
                AverageRating = 5,
                StartDate = new DateTimeOffset(2018, 10, 31, 8, 0, 0, new TimeSpan(0)),
            };            

            var mathValidation = tp.Add(mathCourse);

            Assert.IsNotNull(mathValidation);
            Assert.IsFalse(mathValidation.IsValid);
            Assert.IsTrue(mathValidation.Errors.Count > 0);
            Assert.AreEqual(expectedValidationMessage, mathValidation.Errors[0].ErrorMessage);
        }        

        [DataTestMethod]
        [DataRow("00000000-0000-0000-0000-000000000000", "'Guid' should not be empty.")]
        public void CourseProvider_GuidValidation_Test(string guid, string expectedValidationMessage)
        {
            CourseProvider tp = Container.GetInstance<CourseProvider>();

            var mathCourse = new Course
            {
                Guid = new Guid(guid),
                Name = "MathTest",
                AverageRating = 5,
                StartDate = new DateTimeOffset(2018, 10, 31, 8, 0, 0, new TimeSpan(0)),
            };

            var mathValidation = tp.Add(mathCourse);

            Assert.IsNotNull(mathValidation);
            Assert.IsFalse(mathValidation.IsValid);
            Assert.IsTrue(mathValidation.Errors.Count > 0);
            Assert.AreEqual("'Guid' should not be empty.", mathValidation.Errors[0].ErrorMessage);
        }

        [DataTestMethod]
        [DataRow(2017, "'Start Date' must be greater than '1/1/2018 12:00:00 AM -05:00'.")]
        public void CourseProvider_StartDateValidation_Test(int year, string expectedValidationMessage)
        {
            CourseProvider tp = Container.GetInstance<CourseProvider>();

            var mathCourse = new Course
            {
                Guid = Guid.NewGuid(),
                Name = "MathTest",
                AverageRating = 5,
                StartDate = new DateTimeOffset(year, 10, 31, 8, 0, 0, new TimeSpan(0)),
            };

            var mathValidation = tp.Add(mathCourse);

            Assert.IsNotNull(mathValidation);
            Assert.IsFalse(mathValidation.IsValid);
            Assert.IsTrue(mathValidation.Errors.Count > 0);
            Assert.AreEqual(expectedValidationMessage, mathValidation.Errors[0].ErrorMessage);
        }

        [DataTestMethod]
        [DataRow(-1, "'Average Rating' must be between 0 and 5. You entered -1.")]
        [DataRow(6, "'Average Rating' must be between 0 and 5. You entered 6.")]
        public void CourseProvider_RatingValidation_Test(int rating, string expectedValidationMessage)
        {
            CourseProvider tp = Container.GetInstance<CourseProvider>();

            var mathCourse = new Course
            {
                Guid = Guid.NewGuid(),
                Name = "MathTest",
                AverageRating = rating,
                StartDate = new DateTimeOffset(2018, 10, 31, 8, 0, 0, new TimeSpan(0)),
            };

            var mathValidation = tp.Add(mathCourse);

            Assert.IsNotNull(mathValidation);
            Assert.IsFalse(mathValidation.IsValid);
            Assert.IsTrue(mathValidation.Errors.Count > 0);
            Assert.AreEqual(expectedValidationMessage, mathValidation.Errors[0].ErrorMessage);
        }
    }
}
