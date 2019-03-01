using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.SchoolModel
{
    public partial class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entity)
        {
                    #region Generated Configuration

            entity.ToTable("Department", "School");

            entity.HasIndex(e => e.InstructorID);

            entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");

            entity.Property(e => e.Budget)
                .HasColumnName("Budget")
                .HasColumnType("money");

            entity.Property(e => e.InstructorID).HasColumnName("InstructorID");

            entity.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(50);

            entity.Property(e => e.StartDate).HasColumnName("StartDate");

            entity.HasOne(d => d.Instructor)
                .WithMany(p => p.Departments)
                .HasForeignKey(d => d.InstructorID);
        #endregion

        }

    }
}
