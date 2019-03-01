using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class MDDetailConfiguration : IEntityTypeConfiguration<MDDetail>
    {
        public void Configure(EntityTypeBuilder<MDDetail> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.DetailID);

            entity.ToTable("MDDetail", "dbo");

            entity.Property(e => e.DetailID)
                .HasColumnName("DetailID")
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

            entity.Property(e => e.Dollars)
                .HasColumnName("Dollars")
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.MasterId).HasColumnName("MasterId");

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

            entity.Property(e => e.SomeOtherName)
                .IsRequired()
                .HasColumnName("SomeOtherName")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Version)
                .IsRequired()
                .HasColumnName("Version")
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('1')");

            entity.HasOne(d => d.Master)
                .WithMany(p => p.MDDetails)
                .HasForeignKey(d => d.MasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MDDetail_MDMaster");
        #endregion

        }

    }
}
