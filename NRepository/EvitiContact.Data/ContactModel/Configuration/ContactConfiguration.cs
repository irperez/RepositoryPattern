using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.GUID);

            entity.ToTable("Contact", "dbo");

            entity.Property(e => e.GUID)
                .HasColumnName("GUID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.CompanyName)
                .HasColumnName("CompanyName")
                .HasMaxLength(100);

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.CreatedByUserID).HasColumnName("CreatedByUserID");

            entity.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime");

            entity.Property(e => e.Credentials)
                .HasColumnName("Credentials")
                .HasMaxLength(50);

            entity.Property(e => e.Department)
                .HasColumnName("Department")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50);

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");

            entity.Property(e => e.IsDemo).HasColumnName("IsDemo");

            entity.Property(e => e.IsMd).HasColumnName("IsMd");

            entity.Property(e => e.IsTest).HasColumnName("IsTest");

            entity.Property(e => e.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50);

            entity.Property(e => e.MiddleName)
                .HasColumnName("MiddleName")
                .HasMaxLength(50);

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnName("ModifiedBy")
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedByUserID).HasColumnName("ModifiedByUserID");

            entity.Property(e => e.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime");

            entity.Property(e => e.Prefix)
                .HasColumnName("Prefix")
                .HasMaxLength(50);

            entity.Property(e => e.SSN)
                .HasColumnName("SSN")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Suffix)
                .HasColumnName("Suffix")
                .HasMaxLength(50);

            entity.Property(e => e.Title)
                .HasColumnName("Title")
                .HasMaxLength(50);

            entity.Property(e => e.TypeID).HasColumnName("TypeID");

            entity.Property(e => e.Version)
                .IsRequired()
                .HasColumnName("Version")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Type)
                .WithMany(p => p.Contacts)
                .HasForeignKey(d => d.TypeID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contact_ContactType");
        #endregion

        }

    }
}
