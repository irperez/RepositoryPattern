using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.SchoolModel
{
    public partial class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {
                    #region Generated Configuration

            entity.ToTable("Student", "School");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.EnrollmentDate).HasColumnName("EnrollmentDate");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasMaxLength(50);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasMaxLength(50);
        #endregion

        }

    }
}
