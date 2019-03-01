using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ZipCodesConfiguration : IEntityTypeConfiguration<ZipCodes>
    {
        public void Configure(EntityTypeBuilder<ZipCodes> entity)
        {
                    #region Generated Configuration

            entity.ToTable("ZipCodes", "dbo");

            entity.Property(e => e.ID)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            entity.Property(e => e.City)
                .IsRequired()
                .HasColumnName("City")
                .HasMaxLength(28);

            entity.Property(e => e.Class)
                .HasColumnName("Class")
                .HasMaxLength(1);

            entity.Property(e => e.Latitude)
                .HasColumnName("Latitude")
                .HasMaxLength(256);

            entity.Property(e => e.Longitude)
                .HasColumnName("Longitude")
                .HasMaxLength(256);

            entity.Property(e => e.StateCode).HasColumnName("StateCode");

            entity.Property(e => e.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(5);

            entity.HasOne(d => d.StateCodeNavigation)
                .WithMany(p => p.ZipCodes)
                .HasForeignKey(d => d.StateCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ZipCodes_States");
        #endregion

        }

    }
}
