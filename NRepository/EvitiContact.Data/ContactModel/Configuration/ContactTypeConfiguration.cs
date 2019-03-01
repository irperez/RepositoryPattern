using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> entity)
        {
                    #region Generated Configuration

            entity.ToTable("ContactType", "dbo");

            entity.Property(e => e.ID)
                .HasColumnName("ID")
                .ValueGeneratedNever();

            entity.Property(e => e.Description)
                .HasColumnName("Description")
                .HasColumnType("text");

            entity.Property(e => e.IsActive).HasColumnName("IsActive");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(1000);

            entity.Property(e => e.ParentID).HasColumnName("ParentID");
        #endregion

        }

    }
}
