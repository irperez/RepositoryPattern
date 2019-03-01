using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactUserConfiguration : IEntityTypeConfiguration<ContactUser>
    {
        public void Configure(EntityTypeBuilder<ContactUser> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.UserGUID);

            entity.ToTable("ContactUser", "dbo");

            entity.Property(e => e.UserGUID)
                .HasColumnName("UserGUID")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeId");

            entity.Property(e => e.Comment)
                .HasColumnName("Comment")
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.ContactGuid).HasColumnName("ContactGuid");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("CreatedBy")
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.CreatedByUserID).HasColumnName("CreatedByUserID");

            entity.Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("datetime");

            entity.Property(e => e.IsApproved).HasColumnName("IsApproved");

            entity.Property(e => e.IsComplete).HasColumnName("IsComplete");

            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");

            entity.Property(e => e.IsEvitiManaged).HasColumnName("IsEvitiManaged");

            entity.Property(e => e.IsPasswordRedefineRequired).HasColumnName("IsPasswordRedefineRequired");

            entity.Property(e => e.IsSecurityQuestionRedefineRequired).HasColumnName("IsSecurityQuestionRedefineRequired");

            entity.Property(e => e.ManagerGUID).HasColumnName("ManagerGUID");

            entity.Property(e => e.ModifiedBy)
                .IsRequired()
                .HasColumnName("ModifiedBy")
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.Property(e => e.ModifiedByUserID).HasColumnName("ModifiedByUserID");

            entity.Property(e => e.ModifiedDate)
                .HasColumnName("ModifiedDate")
                .HasColumnType("datetime");

            entity.Property(e => e.SetupCompletedDate)
                .HasColumnName("SetupCompletedDate")
                .HasColumnType("datetime");

            entity.Property(e => e.TSStamp)
                .IsRequired()
                .HasColumnName("TSStamp")
                .IsRowVersion();

            entity.Property(e => e.TermsOfUsedDate)
                .HasColumnName("TermsOfUsedDate")
                .HasColumnType("datetime");

            entity.Property(e => e.TermsOfUserVersion).HasColumnName("TermsOfUserVersion");

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasMaxLength(256);

            entity.Property(e => e.Version)
                .IsRequired()
                .HasColumnName("Version")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ContactGu)
                .WithMany(p => p.ContactUsers)
                .HasForeignKey(d => d.ContactGuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactUser_Contact");
        #endregion

        }

    }
}
