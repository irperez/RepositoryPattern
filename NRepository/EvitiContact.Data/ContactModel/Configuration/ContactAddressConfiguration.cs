using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactAddressConfiguration : IEntityTypeConfiguration<ContactAddress>
    {
        public void Configure(EntityTypeBuilder<ContactAddress> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.GUID);

            entity.ToTable("ContactAddress", "dbo");

            entity.Property(e => e.GUID)
                .HasColumnName("GUID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.City)
                .HasColumnName("City")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.ContactGUID).HasColumnName("ContactGUID");

            entity.Property(e => e.Country)
                .HasColumnName("Country")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.IsPrimary).HasColumnName("IsPrimary");

            entity.Property(e => e.Latitude)
                .HasColumnName("Latitude")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Longitude)
                .HasColumnName("Longitude")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Province)
                .HasColumnName("Province")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.State).HasColumnName("State");

            entity.Property(e => e.Street)
                .HasColumnName("Street")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Street2)
                .HasColumnName("Street2")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.TimeZone)
                .HasColumnName("TimeZone")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.ZipCode)
                .HasColumnName("ZipCode")
                .HasMaxLength(5);

            entity.Property(e => e.ZipCodeExtension)
                .HasColumnName("ZipCodeExtension")
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.ZipCodeString)
                .HasColumnName("ZipCodeString")
                .HasMaxLength(5);

            entity.HasOne(d => d.ContactGU)
                .WithMany(p => p.ContactAddresses)
                .HasForeignKey(d => d.ContactGUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactAddress_Contact");

            entity.HasOne(d => d.StateNavigation)
                .WithMany(p => p.ContactAddresses)
                .HasForeignKey(d => d.State)
                .HasConstraintName("FK_ContactAddress_States");
        #endregion

        }

    }
}
