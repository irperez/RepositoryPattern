using System;
using System.Collections.Generic;

namespace NRepository.UniversityBL.Domain
{
    public class Course
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public int AverageRating { get; set; }
        public List<Topic> Topics { get; set; }
        public DateTimeOffset StartDate { get; set; }
    }
}
