using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactPhoneConfiguration : IEntityTypeConfiguration<ContactPhone>
    {
        public void Configure(EntityTypeBuilder<ContactPhone> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.GUID);

            entity.ToTable("ContactPhone", "dbo");

            entity.Property(e => e.GUID)
                .HasColumnName("GUID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.AreaCode)
                .IsRequired()
                .HasColumnName("AreaCode")
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.Property(e => e.ContactGUID).HasColumnName("ContactGUID");

            entity.Property(e => e.Extension)
                .HasColumnName("Extension")
                .HasMaxLength(10);

            entity.Property(e => e.IsInternational).HasColumnName("IsInternational");

            entity.Property(e => e.IsPrimary).HasColumnName("IsPrimary");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasColumnName("PhoneNumber")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.PhoneTypeId).HasColumnName("PhoneTypeId");

            entity.HasOne(d => d.ContactGU)
                .WithMany(p => p.ContactPhones)
                .HasForeignKey(d => d.ContactGUID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactPhone_Contact");
        #endregion

        }

    }
}
