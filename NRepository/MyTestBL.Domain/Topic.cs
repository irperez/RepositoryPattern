using System;

namespace NRepository.UniversityBL.Domain
{
    public class Topic
    {
        public Guid Guid { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public Guid CourseId { get; set; }
    }
}
