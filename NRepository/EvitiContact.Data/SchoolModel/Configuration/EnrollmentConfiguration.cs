using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.SchoolModel
{
    public partial class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> entity)
        {
                    #region Generated Configuration

            entity.ToTable("Enrollment", "School");

            entity.HasIndex(e => e.CourseID);

            entity.HasIndex(e => e.StudentID);

            entity.Property(e => e.EnrollmentID).HasColumnName("EnrollmentID");

            entity.Property(e => e.CourseID).HasColumnName("CourseID");

            entity.Property(e => e.Grade).HasColumnName("Grade");

            entity.Property(e => e.StudentID).HasColumnName("StudentID");

            entity.HasOne(d => d.Course)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseID);

            entity.HasOne(d => d.Student)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentID);
        #endregion

        }

    }
}
