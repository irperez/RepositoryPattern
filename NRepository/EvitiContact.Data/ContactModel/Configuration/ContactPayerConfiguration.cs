using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvitiContact.ContactModel
{
    public partial class ContactPayerConfiguration : IEntityTypeConfiguration<ContactPayer>
    {
        public void Configure(EntityTypeBuilder<ContactPayer> entity)
        {
                    #region Generated Configuration

            entity.HasKey(e => e.PayerGuid);

            entity.ToTable("ContactPayer", "dbo");

            entity.Property(e => e.PayerGuid)
                .HasColumnName("PayerGuid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.DefaultToEBM).HasColumnName("DefaultToEBM");

            entity.Property(e => e.EligibilityVerifier)
                .HasColumnName("EligibilityVerifier")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.EligibilityVerifierMode).HasColumnName("EligibilityVerifierMode");

            entity.Property(e => e.EntityGuid).HasColumnName("EntityGuid");

            entity.Property(e => e.EvitiDisplayName)
                .HasColumnName("EvitiDisplayName")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.HideNonCompliantRegimens).HasColumnName("HideNonCompliantRegimens");

            entity.Property(e => e.IsActive).HasColumnName("IsActive");

            entity.Property(e => e.IsComplete).HasColumnName("IsComplete");

            entity.Property(e => e.IsDefaultLOBAllowed).HasColumnName("IsDefaultLOBAllowed");

            entity.Property(e => e.IsInPublicList).HasColumnName("IsInPublicList");

            entity.Property(e => e.IsPayerEmailOn).HasColumnName("IsPayerEmailOn");

            entity.Property(e => e.Name)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ParameterDictionary)
                .HasColumnName("ParameterDictionary")
                .IsUnicode(false);

            entity.Property(e => e.PayerID)
                .HasColumnName("PayerID")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PrimaryAdminContact).HasColumnName("PrimaryAdminContact");

            entity.Property(e => e.RegistrationPin)
                .HasColumnName("RegistrationPin")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.RunStateMandateAnalyzer).HasColumnName("RunStateMandateAnalyzer");

            entity.Property(e => e.ShowBiomarkersForChemo).HasColumnName("ShowBiomarkersForChemo");

            entity.Property(e => e.ShowBiomarkersForRadiation).HasColumnName("ShowBiomarkersForRadiation");

            entity.Property(e => e.ShowMatchTrial).HasColumnName("ShowMatchTrial");

            entity.Property(e => e.ShowPerformanceStatus).HasColumnName("ShowPerformanceStatus");

            entity.Property(e => e.ShowPlanCompliantColumn).HasColumnName("ShowPlanCompliantColumn");

            entity.Property(e => e.TreatmentEndDate).HasColumnName("TreatmentEndDate");

            entity.Property(e => e.TurnaroundClockType).HasColumnName("TurnaroundClockType");

            entity.Property(e => e.TurnaroundStandardHours).HasColumnName("TurnaroundStandardHours");

            entity.Property(e => e.TurnaroundUrgentHours).HasColumnName("TurnaroundUrgentHours");
        #endregion

        }

    }
}
