using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shouldly;
using Xunit;

namespace ContactDB.UnitTests
{

 


    public class DataAnnotationsValidationTests
    {
        public ValidationContext GetValidationContext(object validationTarget)
        {
            return new ValidationContext(validationTarget);
        }


        [Fact]
        public void ValidateVideoFails()
        {
            var badVideo = new Video
            {
                Title = string.Empty,
                Description = string.Empty,
                VideoUrl = string.Empty
            };

            var context = GetValidationContext(badVideo);
            var results = new List<ValidationResult>();


            Validator.TryValidateObject(badVideo, context, results, true).ShouldBe(false);
            results.Count.ShouldBe(3);
            results[0].ErrorMessage.ShouldBe("Please enter a title for your video.");
            results[1].ErrorMessage.ShouldBe("Please enter a description for your video.");
            results[2].ErrorMessage.ShouldBe("Please enter a url for your video.");




            //Assert.IsFalse(Validator.TryValidateObject(badVideo, context, results, true));

            //Assert.AreEqual(3, results.Count);

            //Assert.AreEqual("Please enter a title for your video.", results[0].ErrorMessage);
            //Assert.AreEqual("Please enter a description for your video.", results[1].ErrorMessage);
            //Assert.AreEqual("Please enter a url for your video.", results[2].ErrorMessage);
        }


        [Fact]
        public void ValidateVideoSucceeds()
        {
            var goodVideo = new Video
            {
                Title = "Test Title",
                Description = "Test Description",
                VideoUrl = "https://www.tempuri.org"
            };

            var context = GetValidationContext(goodVideo);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(goodVideo, context, results, true).ShouldBe(true);
            results.Count.ShouldBe(0);

            //Assert.IsTrue(Validator.TryValidateObject(goodVideo, context, results, true));

            //Assert.AreEqual(0, results.Count);
        }


        [Fact]
        public void VideoWithBadUrl()
        {
            var badUrlVideo = new Video
            {
                Title = "Test Title",
                Description = "Test Description",
                VideoUrl = "xxx"
            };

            var context = GetValidationContext(badUrlVideo);
            var results = new List<ValidationResult>();

            Validator.TryValidateObject(badUrlVideo, context, results, true).ShouldBe(false);

            results.Count.ShouldBe(2);


            //Assert.IsFalse(Validator.TryValidateObject(badUrlVideo, context, results, true));

            //Assert.AreEqual(2, results.Count);
        }
    }
}
