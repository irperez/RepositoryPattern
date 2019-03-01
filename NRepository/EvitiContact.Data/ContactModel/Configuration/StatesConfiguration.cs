using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class StatesConfiguration : IEntityTypeConfiguration<States>
    {
        public void Configure(EntityTypeBuilder<States> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.StateCode);

            entity.ToTable("States", "dbo");

            entity.Property(e => e.StateCode)
                .HasColumnName("StateCode")
                .ValueGeneratedNever();

            entity.Property(e => e.Abbreviation)
                .HasColumnName("Abbreviation")
                .HasMaxLength(2);

            entity.Property(e => e.IsStandard).HasColumnName("IsStandard");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(15);
        #endregion

        }

    }
}
