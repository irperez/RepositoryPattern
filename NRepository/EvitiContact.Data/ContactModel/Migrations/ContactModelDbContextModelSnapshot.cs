﻿// <auto-generated />
using System;
using EvitiContact.ContactModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EvitiContact.Data.ContactModel.Migrations
{
    [DbContext(typeof(ContactModelDbContext))]
    partial class ContactModelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EvitiContact.ContactModel.AuditLog", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateChanged")
                        .HasColumnName("DateChanged")
                        .HasColumnType("datetime");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnName("EntityName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("EntityState")
                        .IsRequired()
                        .HasColumnName("EntityState")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("NewValue")
                        .HasColumnName("NewValue")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("OldValue")
                        .HasColumnName("OldValue")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PrimaryKeyValue")
                        .HasColumnName("PrimaryKeyValue")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnName("PropertyName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("AuditLog","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.Contact", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GUID");

                    b.Property<string>("CompanyName")
                        .HasColumnName("CompanyName")
                        .HasMaxLength(100);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<Guid?>("CreatedByUserID")
                        .HasColumnName("CreatedByUserID");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Credentials")
                        .HasColumnName("Credentials")
                        .HasMaxLength(50);

                    b.Property<string>("Department")
                        .HasColumnName("Department")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<bool>("IsDemo")
                        .HasColumnName("IsDemo");

                    b.Property<bool>("IsMd")
                        .HasColumnName("IsMd");

                    b.Property<bool?>("IsTest")
                        .HasColumnName("IsTest");

                    b.Property<string>("LastName")
                        .HasColumnName("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("MiddleName")
                        .HasColumnName("MiddleName")
                        .HasMaxLength(50);

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<Guid?>("ModifiedByUserID")
                        .HasColumnName("ModifiedByUserID");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Prefix")
                        .HasColumnName("Prefix")
                        .HasMaxLength(50);

                    b.Property<string>("SSN")
                        .HasColumnName("SSN")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Suffix")
                        .HasColumnName("Suffix")
                        .HasMaxLength(50);

                    b.Property<string>("Title")
                        .HasColumnName("Title")
                        .HasMaxLength(50);

                    b.Property<int>("TypeID")
                        .HasColumnName("TypeID");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnName("Version")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("GUID");

                    b.HasIndex("TypeID");

                    b.ToTable("Contact","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactAddress", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GUID");

                    b.Property<string>("City")
                        .HasColumnName("City")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<Guid>("ContactGUID")
                        .HasColumnName("ContactGUID");

                    b.Property<string>("Country")
                        .HasColumnName("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool>("IsPrimary")
                        .HasColumnName("IsPrimary");

                    b.Property<string>("Latitude")
                        .HasColumnName("Latitude")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Longitude")
                        .HasColumnName("Longitude")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Province")
                        .HasColumnName("Province")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("State")
                        .HasColumnName("State");

                    b.Property<string>("Street")
                        .HasColumnName("Street")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Street2")
                        .HasColumnName("Street2")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("TimeZone")
                        .HasColumnName("TimeZone")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ZipCode")
                        .HasColumnName("ZipCode")
                        .HasMaxLength(5);

                    b.Property<string>("ZipCodeExtension")
                        .HasColumnName("ZipCodeExtension")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("ZipCodeString")
                        .HasColumnName("ZipCodeString")
                        .HasMaxLength(5);

                    b.HasKey("GUID");

                    b.HasIndex("ContactGUID");

                    b.HasIndex("State");

                    b.ToTable("ContactAddress","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactEmail", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Guid");

                    b.Property<Guid>("ContactGuid")
                        .HasColumnName("ContactGuid");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("EmailAddress")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<bool>("IsPrimary")
                        .HasColumnName("IsPrimary");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Guid");

                    b.HasIndex("ContactGuid");

                    b.ToTable("ContactEmail","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactExternalIDs", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Guid");

                    b.Property<Guid?>("ApplicationOwnerGuid")
                        .HasColumnName("ApplicationOwnerGuid");

                    b.Property<Guid>("ContactGuid")
                        .HasColumnName("ContactGuid");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnName("Identifier")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Guid");

                    b.HasIndex("ContactGuid");

                    b.ToTable("ContactExternalIDs","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactPayer", b =>
                {
                    b.Property<Guid>("PayerGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PayerGuid");

                    b.Property<bool>("DefaultToEBM")
                        .HasColumnName("DefaultToEBM");

                    b.Property<string>("EligibilityVerifier")
                        .HasColumnName("EligibilityVerifier")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("EligibilityVerifierMode")
                        .HasColumnName("EligibilityVerifierMode");

                    b.Property<Guid?>("EntityGuid")
                        .HasColumnName("EntityGuid");

                    b.Property<string>("EvitiDisplayName")
                        .HasColumnName("EvitiDisplayName")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool>("HideNonCompliantRegimens")
                        .HasColumnName("HideNonCompliantRegimens");

                    b.Property<bool>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<bool?>("IsComplete")
                        .HasColumnName("IsComplete");

                    b.Property<bool>("IsDefaultLOBAllowed")
                        .HasColumnName("IsDefaultLOBAllowed");

                    b.Property<bool>("IsInPublicList")
                        .HasColumnName("IsInPublicList");

                    b.Property<bool>("IsPayerEmailOn")
                        .HasColumnName("IsPayerEmailOn");

                    b.Property<string>("Name")
                        .HasColumnName("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ParameterDictionary")
                        .HasColumnName("ParameterDictionary")
                        .IsUnicode(false);

                    b.Property<string>("PayerID")
                        .HasColumnName("PayerID")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<Guid?>("PrimaryAdminContact")
                        .HasColumnName("PrimaryAdminContact");

                    b.Property<string>("RegistrationPin")
                        .HasColumnName("RegistrationPin")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("RunStateMandateAnalyzer")
                        .HasColumnName("RunStateMandateAnalyzer");

                    b.Property<bool>("ShowBiomarkersForChemo")
                        .HasColumnName("ShowBiomarkersForChemo");

                    b.Property<bool>("ShowBiomarkersForRadiation")
                        .HasColumnName("ShowBiomarkersForRadiation");

                    b.Property<bool>("ShowMatchTrial")
                        .HasColumnName("ShowMatchTrial");

                    b.Property<bool>("ShowPerformanceStatus")
                        .HasColumnName("ShowPerformanceStatus");

                    b.Property<bool>("ShowPlanCompliantColumn")
                        .HasColumnName("ShowPlanCompliantColumn");

                    b.Property<int>("TreatmentEndDate")
                        .HasColumnName("TreatmentEndDate");

                    b.Property<int>("TurnaroundClockType")
                        .HasColumnName("TurnaroundClockType");

                    b.Property<int>("TurnaroundStandardHours")
                        .HasColumnName("TurnaroundStandardHours");

                    b.Property<int>("TurnaroundUrgentHours")
                        .HasColumnName("TurnaroundUrgentHours");

                    b.HasKey("PayerGuid");

                    b.ToTable("ContactPayer","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactPhone", b =>
                {
                    b.Property<Guid>("GUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("GUID");

                    b.Property<string>("AreaCode")
                        .IsRequired()
                        .HasColumnName("AreaCode")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.Property<Guid>("ContactGUID")
                        .HasColumnName("ContactGUID");

                    b.Property<string>("Extension")
                        .HasColumnName("Extension")
                        .HasMaxLength(10);

                    b.Property<bool>("IsInternational")
                        .HasColumnName("IsInternational");

                    b.Property<bool>("IsPrimary")
                        .HasColumnName("IsPrimary");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("PhoneNumber")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<int>("PhoneTypeId")
                        .HasColumnName("PhoneTypeId");

                    b.HasKey("GUID");

                    b.HasIndex("ContactGUID");

                    b.ToTable("ContactPhone","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactType", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("text");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(1000);

                    b.Property<int?>("ParentID")
                        .HasColumnName("ParentID");

                    b.HasKey("ID");

                    b.ToTable("ContactType","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactUser", b =>
                {
                    b.Property<Guid>("UserGUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserGUID");

                    b.Property<int>("AccountTypeId")
                        .HasColumnName("AccountTypeId");

                    b.Property<string>("Comment")
                        .HasColumnName("Comment")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<Guid>("ContactGuid")
                        .HasColumnName("ContactGuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("CreatedBy")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<Guid?>("CreatedByUserID")
                        .HasColumnName("CreatedByUserID");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsApproved")
                        .HasColumnName("IsApproved");

                    b.Property<bool>("IsComplete")
                        .HasColumnName("IsComplete");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IsDeleted");

                    b.Property<bool>("IsEvitiManaged")
                        .HasColumnName("IsEvitiManaged");

                    b.Property<bool>("IsPasswordRedefineRequired")
                        .HasColumnName("IsPasswordRedefineRequired");

                    b.Property<bool>("IsSecurityQuestionRedefineRequired")
                        .HasColumnName("IsSecurityQuestionRedefineRequired");

                    b.Property<Guid?>("ManagerGUID")
                        .HasColumnName("ManagerGUID");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnName("ModifiedBy")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<Guid?>("ModifiedByUserID")
                        .HasColumnName("ModifiedByUserID");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnName("ModifiedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("SetupCompletedDate")
                        .HasColumnName("SetupCompletedDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("TSStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("TSStamp");

                    b.Property<DateTime?>("TermsOfUsedDate")
                        .HasColumnName("TermsOfUsedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("TermsOfUserVersion")
                        .HasColumnName("TermsOfUserVersion");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnName("Version")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("UserGUID");

                    b.HasIndex("ContactGuid");

                    b.ToTable("ContactUser","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.MDDetail", b =>
                {
                    b.Property<Guid>("DetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DetailID");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CreatedBy")
                        .HasDefaultValueSql("('bob')")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CreatedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal?>("Dollars")
                        .HasColumnName("Dollars")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<Guid>("MasterId")
                        .HasColumnName("MasterId");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ModifiedBy")
                        .HasDefaultValueSql("('bob')")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ModifiedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("SomeOtherName")
                        .IsRequired()
                        .HasColumnName("SomeOtherName")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Version")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Version")
                        .HasDefaultValueSql("('1')")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("DetailID");

                    b.HasIndex("MasterId");

                    b.ToTable("MDDetail","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.MDMaster", b =>
                {
                    b.Property<Guid>("MasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MasterId");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CreatedBy")
                        .HasDefaultValueSql("('bob')")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CreatedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ModifiedBy")
                        .HasDefaultValueSql("('bob')")
                        .HasMaxLength(256)
                        .IsUnicode(false);

                    b.Property<DateTime>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ModifiedDate")
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<decimal>("NewRequired")
                        .HasColumnName("NewRequired")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("RowVersion");

                    b.Property<decimal?>("TotalDollars")
                        .HasColumnName("TotalDollars")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Version")
                        .HasDefaultValueSql("('1')")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("MasterId");

                    b.ToTable("MDMaster","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.States", b =>
                {
                    b.Property<int>("StateCode")
                        .HasColumnName("StateCode");

                    b.Property<string>("Abbreviation")
                        .HasColumnName("Abbreviation")
                        .HasMaxLength(2);

                    b.Property<bool>("IsStandard")
                        .HasColumnName("IsStandard");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasMaxLength(15);

                    b.HasKey("StateCode");

                    b.ToTable("States","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ZipCodes", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnName("ID");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("City")
                        .HasMaxLength(28);

                    b.Property<string>("Class")
                        .HasColumnName("Class")
                        .HasMaxLength(1);

                    b.Property<string>("Latitude")
                        .HasColumnName("Latitude")
                        .HasMaxLength(256);

                    b.Property<string>("Longitude")
                        .HasColumnName("Longitude")
                        .HasMaxLength(256);

                    b.Property<int>("StateCode")
                        .HasColumnName("StateCode");

                    b.Property<string>("ZipCode")
                        .HasColumnName("ZipCode")
                        .HasMaxLength(5);

                    b.HasKey("ID");

                    b.HasIndex("StateCode");

                    b.ToTable("ZipCodes","dbo");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.Contact", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.ContactType", "Type")
                        .WithMany("Contacts")
                        .HasForeignKey("TypeID")
                        .HasConstraintName("FK_Contact_ContactType");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactAddress", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.Contact", "ContactGU")
                        .WithMany("ContactAddresses")
                        .HasForeignKey("ContactGUID")
                        .HasConstraintName("FK_ContactAddress_Contact");

                    b.HasOne("EvitiContact.ContactModel.States", "StateNavigation")
                        .WithMany("ContactAddresses")
                        .HasForeignKey("State")
                        .HasConstraintName("FK_ContactAddress_States");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactEmail", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.Contact", "ContactGu")
                        .WithMany("ContactEmails")
                        .HasForeignKey("ContactGuid")
                        .HasConstraintName("FK_ContactEmail_Contact");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactExternalIDs", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.Contact", "ContactGu")
                        .WithMany("ContactExternalIDs")
                        .HasForeignKey("ContactGuid")
                        .HasConstraintName("FK_ContactExternalIDs_Contact");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactPhone", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.Contact", "ContactGU")
                        .WithMany("ContactPhones")
                        .HasForeignKey("ContactGUID")
                        .HasConstraintName("FK_ContactPhone_Contact");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ContactUser", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.Contact", "ContactGu")
                        .WithMany("ContactUsers")
                        .HasForeignKey("ContactGuid")
                        .HasConstraintName("FK_ContactUser_Contact");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.MDDetail", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.MDMaster", "Master")
                        .WithMany("MDDetails")
                        .HasForeignKey("MasterId")
                        .HasConstraintName("FK_MDDetail_MDMaster");
                });

            modelBuilder.Entity("EvitiContact.ContactModel.ZipCodes", b =>
                {
                    b.HasOne("EvitiContact.ContactModel.States", "StateCodeNavigation")
                        .WithMany("ZipCodes")
                        .HasForeignKey("StateCode")
                        .HasConstraintName("FK_ZipCodes_States");
                });
#pragma warning restore 612, 618
        }
    }
}
