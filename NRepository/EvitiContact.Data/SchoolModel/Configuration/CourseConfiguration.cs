using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.SchoolModel
{
    public partial class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
                    #region Generated Configuration

            entity.ToTable("Course", "School");

            entity.HasIndex(e => e.DepartmentID);

            entity.Property(e => e.CourseID)
                .HasColumnName("CourseID")
                .ValueGeneratedNever();

            entity.Property(e => e.Credits).HasColumnName("Credits");

            entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");

            entity.Property(e => e.Title)
                .HasColumnName("Title")
                .HasMaxLength(50);

            entity.HasOne(d => d.Department)
                .WithMany(p => p.Courses)
                .HasForeignKey(d => d.DepartmentID);
        #endregion

        }

    }
}
