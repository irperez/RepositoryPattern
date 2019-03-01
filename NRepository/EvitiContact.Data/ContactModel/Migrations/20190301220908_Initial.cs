using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvitiContact.Data.ContactModel.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AuditLog",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    EntityName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PropertyName = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PrimaryKeyValue = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    OldValue = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    NewValue = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime", nullable: false),
                    EntityState = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPayer",
                schema: "dbo",
                columns: table => new
                {
                    PayerGuid = table.Column<Guid>(nullable: false),
                    PayerID = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DefaultToEBM = table.Column<bool>(nullable: false),
                    EligibilityVerifier = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EligibilityVerifierMode = table.Column<int>(nullable: true),
                    PrimaryAdminContact = table.Column<Guid>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: true),
                    RegistrationPin = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    EvitiDisplayName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ParameterDictionary = table.Column<string>(unicode: false, nullable: true),
                    IsInPublicList = table.Column<bool>(nullable: false),
                    EntityGuid = table.Column<Guid>(nullable: true),
                    IsPayerEmailOn = table.Column<bool>(nullable: false),
                    HideNonCompliantRegimens = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ShowPerformanceStatus = table.Column<bool>(nullable: false),
                    ShowPlanCompliantColumn = table.Column<bool>(nullable: false),
                    ShowBiomarkersForChemo = table.Column<bool>(nullable: false),
                    ShowBiomarkersForRadiation = table.Column<bool>(nullable: false),
                    TreatmentEndDate = table.Column<int>(nullable: false),
                    TurnaroundUrgentHours = table.Column<int>(nullable: false),
                    TurnaroundStandardHours = table.Column<int>(nullable: false),
                    TurnaroundClockType = table.Column<int>(nullable: false),
                    RunStateMandateAnalyzer = table.Column<bool>(nullable: false),
                    IsDefaultLOBAllowed = table.Column<bool>(nullable: false),
                    ShowMatchTrial = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPayer", x => x.PayerGuid);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ParentID = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MDMaster",
                schema: "dbo",
                columns: table => new
                {
                    MasterId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TotalDollars = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    NewRequired = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Version = table.Column<string>(unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('1')"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false, defaultValueSql: "('bob')"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false, defaultValueSql: "('bob')"),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MDMaster", x => x.MasterId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "dbo",
                columns: table => new
                {
                    StateCode = table.Column<int>(nullable: false),
                    Abbreviation = table.Column<string>(maxLength: 2, nullable: true),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    IsStandard = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateCode);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "dbo",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Credentials = table.Column<string>(maxLength: 50, nullable: true),
                    Prefix = table.Column<string>(maxLength: 50, nullable: true),
                    Suffix = table.Column<string>(maxLength: 50, nullable: true),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: true),
                    TypeID = table.Column<int>(nullable: false),
                    IsMd = table.Column<bool>(nullable: false),
                    Version = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    SSN = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IsTest = table.Column<bool>(nullable: true),
                    IsDemo = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Department = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CreatedByUserID = table.Column<Guid>(nullable: true),
                    ModifiedByUserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Contact_ContactType",
                        column: x => x.TypeID,
                        principalSchema: "dbo",
                        principalTable: "ContactType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MDDetail",
                schema: "dbo",
                columns: table => new
                {
                    DetailID = table.Column<Guid>(nullable: false),
                    MasterId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SomeOtherName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Dollars = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Version = table.Column<string>(unicode: false, maxLength: 50, nullable: false, defaultValueSql: "('1')"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false, defaultValueSql: "('bob')"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false, defaultValueSql: "('bob')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MDDetail", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_MDDetail_MDMaster",
                        column: x => x.MasterId,
                        principalSchema: "dbo",
                        principalTable: "MDMaster",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true),
                    Latitude = table.Column<string>(maxLength: 256, nullable: true),
                    Longitude = table.Column<string>(maxLength: 256, nullable: true),
                    Class = table.Column<string>(maxLength: 1, nullable: true),
                    City = table.Column<string>(maxLength: 28, nullable: false),
                    StateCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ZipCodes_States",
                        column: x => x.StateCode,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactAddress",
                schema: "dbo",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    ContactGUID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Street = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Street2 = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    State = table.Column<int>(nullable: true),
                    Province = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    ZipCodeExtension = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    TimeZone = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Longitude = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Latitude = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    ZipCodeString = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddress", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_ContactAddress_Contact",
                        column: x => x.ContactGUID,
                        principalSchema: "dbo",
                        principalTable: "Contact",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactAddress_States",
                        column: x => x.State,
                        principalSchema: "dbo",
                        principalTable: "States",
                        principalColumn: "StateCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactEmail",
                schema: "dbo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ContactGuid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactEmail", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ContactEmail_Contact",
                        column: x => x.ContactGuid,
                        principalSchema: "dbo",
                        principalTable: "Contact",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactExternalIDs",
                schema: "dbo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ContactGuid = table.Column<Guid>(nullable: false),
                    Identifier = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    ApplicationOwnerGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactExternalIDs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ContactExternalIDs_Contact",
                        column: x => x.ContactGuid,
                        principalSchema: "dbo",
                        principalTable: "Contact",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactPhone",
                schema: "dbo",
                columns: table => new
                {
                    GUID = table.Column<Guid>(nullable: false),
                    ContactGUID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    AreaCode = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    PhoneNumber = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Extension = table.Column<string>(maxLength: 10, nullable: true),
                    IsInternational = table.Column<bool>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    PhoneTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPhone", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_ContactPhone_Contact",
                        column: x => x.ContactGUID,
                        principalSchema: "dbo",
                        principalTable: "Contact",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUser",
                schema: "dbo",
                columns: table => new
                {
                    UserGUID = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    ManagerGUID = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(unicode: false, maxLength: 256, nullable: false),
                    Version = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ContactGuid = table.Column<Guid>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    TermsOfUserVersion = table.Column<int>(nullable: true),
                    TermsOfUsedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    IsSecurityQuestionRedefineRequired = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsPasswordRedefineRequired = table.Column<bool>(nullable: false),
                    SetupCompletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AccountTypeId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    TSStamp = table.Column<byte[]>(rowVersion: true, nullable: false),
                    IsEvitiManaged = table.Column<bool>(nullable: false),
                    CreatedByUserID = table.Column<Guid>(nullable: true),
                    ModifiedByUserID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUser", x => x.UserGUID);
                    table.ForeignKey(
                        name: "FK_ContactUser_Contact",
                        column: x => x.ContactGuid,
                        principalSchema: "dbo",
                        principalTable: "Contact",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_TypeID",
                schema: "dbo",
                table: "Contact",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_ContactGUID",
                schema: "dbo",
                table: "ContactAddress",
                column: "ContactGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_State",
                schema: "dbo",
                table: "ContactAddress",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_ContactEmail_ContactGuid",
                schema: "dbo",
                table: "ContactEmail",
                column: "ContactGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ContactExternalIDs_ContactGuid",
                schema: "dbo",
                table: "ContactExternalIDs",
                column: "ContactGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPhone_ContactGUID",
                schema: "dbo",
                table: "ContactPhone",
                column: "ContactGUID");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUser_ContactGuid",
                schema: "dbo",
                table: "ContactUser",
                column: "ContactGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MDDetail_MasterId",
                schema: "dbo",
                table: "MDDetail",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ZipCodes_StateCode",
                schema: "dbo",
                table: "ZipCodes",
                column: "StateCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactAddress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactEmail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactExternalIDs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactPayer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactPhone",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MDDetail",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ZipCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MDMaster",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "States",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "dbo");
        }
    }
}
