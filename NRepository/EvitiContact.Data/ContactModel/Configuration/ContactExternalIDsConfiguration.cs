using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactExternalIDsConfiguration : IEntityTypeConfiguration<ContactExternalIDs>
    {
        public void Configure(EntityTypeBuilder<ContactExternalIDs> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.Guid);

            entity.ToTable("ContactExternalIDs", "dbo");

            entity.Property(e => e.Guid)
                .HasColumnName("Guid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.ApplicationOwnerGuid).HasColumnName("ApplicationOwnerGuid");

            entity.Property(e => e.ContactGuid).HasColumnName("ContactGuid");

            entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Identifier)
                .IsRequired()
                .HasColumnName("Identifier")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.ContactGu)
                .WithMany(p => p.ContactExternalIDs)
                .HasForeignKey(d => d.ContactGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactExternalIDs_Contact");
        #endregion

        }

    }
}
