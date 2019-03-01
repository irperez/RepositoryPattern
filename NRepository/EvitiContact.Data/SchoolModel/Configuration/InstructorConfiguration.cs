using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.SchoolModel
{
    public partial class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> entity)
        {
                    #region Generated Configuration

            entity.ToTable("Instructor", "School");

            entity.Property(e => e.ID).HasColumnName("ID");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasMaxLength(50);

            entity.Property(e => e.HireDate).HasColumnName("HireDate");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasMaxLength(50);
        #endregion

        }

    }
}
