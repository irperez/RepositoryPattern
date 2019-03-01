using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactEmailConfiguration : IEntityTypeConfiguration<ContactEmail>
    {
        public void Configure(EntityTypeBuilder<ContactEmail> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.Guid);

            entity.ToTable("ContactEmail", "dbo");

            entity.Property(e => e.Guid)
                .HasColumnName("Guid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ContactGuid).HasColumnName("ContactGuid");

            entity.Property(e => e.EmailAddress)
                .IsRequired()
                .HasColumnName("EmailAddress")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.IsPrimary).HasColumnName("IsPrimary");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ContactGu)
                .WithMany(p => p.ContactEmails)
                .HasForeignKey(d => d.ContactGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactEmail_Contact");
        #endregion

        }

    }
}
