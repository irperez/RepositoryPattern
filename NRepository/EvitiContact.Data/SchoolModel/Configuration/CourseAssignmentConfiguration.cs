using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.SchoolModel
{
    public partial class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => new { e.CourseID, e.InstructorID });

            entity.ToTable("CourseAssignment", "School");

            entity.HasIndex(e => e.InstructorID);

            entity.Property(e => e.CourseID).HasColumnName("CourseID");

            entity.Property(e => e.InstructorID).HasColumnName("InstructorID");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.CourseID);

            entity.HasOne(d => d.Instructor)
                .WithMany(p => p.CourseAssignments)
                .HasForeignKey(d => d.InstructorID);
        #endregion

        }

    }
}
