using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> entity)
        {
                    #region Generated Configuration

            entity.ToTable("AuditLog", "dbo");

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedNever();

            entity.Property(e => e.DateChanged)
                .HasColumnName("DateChanged")
                .HasColumnType("datetime");

            entity.Property(e => e.EntityName)
                .IsRequired()
                .HasColumnName("EntityName")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.EntityState)
                .IsRequired()
                .HasColumnName("EntityState")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.NewValue)
                .HasColumnName("NewValue")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.OldValue)
                .HasColumnName("OldValue")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PrimaryKeyValue)
                .HasColumnName("PrimaryKeyValue")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.PropertyName)
                .IsRequired()
                .HasColumnName("PropertyName")
                .HasMaxLength(100)
                .IsUnicode(false);
        #endregion

        }

    }
}
