using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class MDMasterConfiguration : IEntityTypeConfiguration<MDMaster>
    {
        public void Configure(EntityTypeBuilder<MDMaster> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.MasterId);

            entity.ToTable("MDMaster", "dbo");

            entity.Property(e => e.MasterId)
                .HasColumnName("MasterId")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('bob')");

            entity.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnName("ModifiedBy")
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasDefaultValueSql("('bob')");

            entity.Property(e => e.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NewRequired)
                .HasColumnName("NewRequired")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.RowVersion)
                .IsRequired()
                .HasColumnName("RowVersion")
                .IsRowVersion();

            entity.Property(e => e.TotalDollars)
                .HasColumnName("TotalDollars")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Version)
                .IsRequired()
                .HasColumnName("Version")
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('1')");
        #endregion

        }

    }
}
