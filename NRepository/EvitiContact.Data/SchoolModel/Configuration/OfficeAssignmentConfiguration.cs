using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.SchoolModel
{
    public partial class OfficeAssignmentConfiguration : IEntityTypeConfiguration<OfficeAssignment>
    {
        public void Configure(EntityTypeBuilder<OfficeAssignment> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.InstructorID);

            entity.ToTable("OfficeAssignment", "School");

            entity.Property(e => e.InstructorID)
                .HasColumnName("InstructorID")
                .ValueGeneratedNever();

            entity.Property(e => e.Location)
                .HasColumnName("Location")
                .HasMaxLength(50);

            entity.HasOne(d => d.Instructor)
                .WithOne(p => p.OfficeAssignment)
                .HasForeignKey<OfficeAssignment>(d => d.InstructorID);
        #endregion

        }

    }
}
