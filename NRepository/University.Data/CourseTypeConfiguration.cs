using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NRepository.UniversityBL.Domain;

namespace University.Data
{
    public class CourseTypeConfiguration : IEntityTypeConfiguration<Course>
    {        
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(p => p.Guid);

            builder.HasMany(b => b.Topics)
                   .WithOne()
                   .HasForeignKey(p => p.CourseId);

            builder.Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}
