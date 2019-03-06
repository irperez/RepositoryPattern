using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactDB.UnitTests
{
    public partial class Video
    {
        private static List<Video> categorizedVideos;

        private SkillLevel? level = null;

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a title for your video.")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a description for your video.")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [VideoUrlIsHttps]
        [Url]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a url for your video.")]
        public string VideoUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public Category Category { get; set; }

        public SkillLevel Level
        {
            get
            {
                if (level == null)
                {
                    var rand = new System.Random();

                    level = (SkillLevel)rand.Next(1, 4);
                }

                return level.Value;
            }
        }
    }

    public enum SkillLevel
    {
        Beginner = 1,
        Intermediate = 2,
        Advanced = 3
    }
}
