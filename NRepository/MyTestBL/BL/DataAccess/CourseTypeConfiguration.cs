using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NRepository.UniversityBL.Domain;

namespace NRepository.UniversityBL.BL.DataAccess
{
    public class CourseTypeConfiguration : IEntityTypeConfiguration<Course>
    {        
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(p => p.Guid);

            builder.HasMany(b => b.Topics)
                   .WithOne()
                   .HasForeignKey(p => p.CourseId);
        }
    }
}
