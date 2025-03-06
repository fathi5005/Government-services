using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Government.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiledName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ServiceDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProcessingTime = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestStatus = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: "Pending"),
                    ResponseStatus = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: "No Response"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequiredDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequiredDocuments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceFields_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceFields_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdminResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminResponses_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdminResponses_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttachedDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttachedDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttachedDocuments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldValueString = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FieldValueInt = table.Column<int>(type: "int", nullable: true),
                    FieldValueFloat = table.Column<float>(type: "real", nullable: true),
                    FieldValueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceData_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceData_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Description", "FiledName" },
                values: new object[,]
                {
                    { 1, "Enter your full name as per official records.", "Full Name" },
                    { 2, "Select your date of birth.", "Date of Birth" },
                    { 3, "Provide your national ID number.", "National ID Number" },
                    { 4, "Enter your passport number.", "Passport Number" },
                    { 5, "Enter your residential address.", "Address" },
                    { 6, "Provide a valid phone number.", "Phone Number" },
                    { 7, "Provide your email for notifications.", "Email Address" },
                    { 8, "Select your marital status.", "Marital Status" },
                    { 9, "Enter your spouse’s full name (if married).", "Spouse Name" },
                    { 10, "Enter your vehicle registration number.", "Vehicle Registration Number" },
                    { 11, "Enter your driver’s license number.", "Driving License Number" },
                    { 12, "Specify your employment status.", "Employment Status" },
                    { 13, "Enter the name of your employer or company.", "Company Name" },
                    { 14, "Provide your estimated annual income.", "Annual Income" },
                    { 15, "Enter your tax ID number.", "Tax Identification Number" },
                    { 16, "Select your nationality.", "Nationality" },
                    { 17, "Enter your place of birth.", "Place of Birth" },
                    { 18, "Select your highest level of education.", "Education Level" },
                    { 19, "Provide your medical insurance number.", "Medical Insurance Number" },
                    { 20, "Select your blood type.", "Blood Type" },
                    { 21, "Enter the name of your emergency contact.", "Emergency Contact Name" },
                    { 22, "Provide the phone number of your emergency contact.", "Emergency Contact Phone" },
                    { 23, "Enter your property ownership certificate number.", "Property Ownership Number" },
                    { 24, "Provide your work permit number (if applicable).", "Work Permit Number" },
                    { 25, "Enter your residency permit number.", "Residency Permit Number" },
                    { 26, "Enter your business license registration number.", "Business License Number" },
                    { 27, "Specify the number of dependents you have.", "Number of Dependents" },
                    { 28, "Enter your bank account number.", "Bank Account Number" },
                    { 29, "Select your preferred language for communication.", "Preferred Language" },
                    { 30, "Enter your previous passport number (if applicable).", "Previous Passport Number" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ContactInfo", "Fee", "IsAvailable", "ProcessingTime", "ServiceDescription", "ServiceName" },
                values: new object[,]
                {
                    { 1, "support@gov.com", 50.00m, true, "5 business days", "Renew your passport quickly and easily.", "Passport Renewal" },
                    { 2, "dmv@gov.com", 30.00m, true, "7 business days", "Apply for a new driver’s license.", "Driver’s License Issuance" },
                    { 3, "transport@gov.com", 40.00m, true, "3 business days", "Register your vehicle with the transport department.", "Vehicle Registration" },
                    { 4, "civilstatus@gov.com", 20.00m, true, "4 business days", "Request an official marriage certificate.", "Marriage Certificate Issuance" },
                    { 5, "registry@gov.com", 15.00m, true, "2 business days", "Obtain an official birth certificate.", "Birth Certificate Issuance" },
                    { 6, "nid@gov.com", 10.00m, true, "6 business days", "Apply for a new national ID card.", "National ID Card Application" },
                    { 7, "business@gov.com", 100.00m, true, "10 business days", "Register your new business legally.", "Business License Registration" },
                    { 8, "labor@gov.com", 70.00m, true, "8 business days", "Apply for a work permit for foreign employees.", "Work Permit Issuance" },
                    { 9, "immigration@gov.com", 60.00m, true, "7 business days", "Renew your residency permit.", "Residency Permit Renewal" },
                    { 10, "tax@gov.com", 25.00m, true, "5 business days", "Register for tax purposes.", "Tax Registration" }
                });

            migrationBuilder.InsertData(
                table: "RequiredDocuments",
                columns: new[] { "Id", "Description", "DocumentType", "FileName", "FileUrl", "IsMandatory", "ServiceId" },
                values: new object[,]
                {
                    { 1, "A copy of a valid passport to verify identity.", "Identification", "Passport Copy", "https://gov.com/docs/passport_copy.pdf", true, 1 },
                    { 2, "A copy of the previous passport, if applicable, for verification.", "Previous Document", "Old Passport", "https://gov.com/docs/old_passport.pdf", true, 1 },
                    { 3, "A scanned copy of the national ID card for identity confirmation.", "Identification", "National ID Copy", "https://gov.com/docs/national_id.pdf", true, 2 },
                    { 4, "A medical certificate proving health status, issued by an authorized medical institution.", "Health", "Medical Certificate", "https://gov.com/docs/medical_certificate.pdf", true, 2 },
                    { 5, "An official document proving ownership of the vehicle.", "Ownership Proof", "Vehicle Title", "https://gov.com/docs/vehicle_title.pdf", true, 3 },
                    { 6, "A valid insurance certificate covering the vehicle.", "Insurance", "Insurance Certificate", "https://gov.com/docs/insurance.pdf", true, 3 },
                    { 7, "A certified copy of the marriage contract for legal purposes.", "Legal", "Marriage Contract", "https://gov.com/docs/marriage_contract.pdf", true, 4 },
                    { 8, "Copies of the national ID cards of both spouses for verification.", "Identification", "National ID Copies", "https://gov.com/docs/nid_copies.pdf", true, 4 },
                    { 9, "An official hospital birth record confirming birth details.", "Medical", "Hospital Birth Record", "https://gov.com/docs/birth_record.pdf", true, 5 },
                    { 10, "Copies of both parents' national ID cards for identity verification.", "Identification", "Parents ID Copies", "https://gov.com/docs/parents_id.pdf", true, 5 },
                    { 11, "A certified copy of the birth certificate for identity confirmation.", "Identification", "Birth Certificate", "https://gov.com/docs/birth_certificate.pdf", true, 6 },
                    { 12, "An official document verifying the applicant's residential address.", "Address Verification", "Proof of Residence", "https://gov.com/docs/proof_residence.pdf", true, 6 },
                    { 13, "An official business registration document confirming legal status.", "Legal", "Business Registration Form", "https://gov.com/docs/business_registration.pdf", true, 7 },
                    { 14, "A tax clearance certificate proving tax compliance.", "Tax", "Tax Clearance Certificate", "https://gov.com/docs/tax_clearance.pdf", true, 7 },
                    { 15, "A signed employment contract detailing job terms and conditions.", "Legal", "Employment Contract", "https://gov.com/docs/employment_contract.pdf", true, 8 },
                    { 16, "An official company license issued by the regulatory authority.", "Business", "Company License", "https://gov.com/docs/company_license.pdf", true, 8 },
                    { 17, "A copy of the residency card confirming residency status.", "Identification", "Residency Card Copy", "https://gov.com/docs/residency_card.pdf", true, 9 },
                    { 18, "A valid rental agreement proving residency at the stated address.", "Proof of Address", "Rental Agreement", "https://gov.com/docs/rental_agreement.pdf", true, 9 },
                    { 19, "A completed tax application form for tax registration.", "Tax", "Tax Application Form", "https://gov.com/docs/tax_application.pdf", true, 10 },
                    { 20, "An official document proving the applicant's income source.", "Financial", "Proof of Income", "https://gov.com/docs/proof_income.pdf", true, 10 }
                });

            migrationBuilder.InsertData(
                table: "ServiceFields",
                columns: new[] { "Id", "FieldId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 4, 1 },
                    { 4, 16, 1 },
                    { 5, 30, 1 },
                    { 6, 6, 1 },
                    { 7, 1, 2 },
                    { 8, 2, 2 },
                    { 9, 3, 2 },
                    { 10, 6, 2 },
                    { 11, 10, 2 },
                    { 12, 11, 2 },
                    { 13, 1, 3 },
                    { 14, 3, 3 },
                    { 15, 6, 3 },
                    { 16, 10, 3 },
                    { 17, 15, 3 },
                    { 18, 23, 3 },
                    { 19, 1, 4 },
                    { 20, 2, 4 },
                    { 21, 17, 4 },
                    { 22, 16, 4 },
                    { 23, 21, 4 },
                    { 24, 22, 4 },
                    { 25, 1, 5 },
                    { 26, 2, 5 },
                    { 27, 3, 5 },
                    { 28, 5, 5 },
                    { 29, 6, 5 },
                    { 30, 7, 5 },
                    { 31, 16, 5 },
                    { 32, 1, 6 },
                    { 33, 6, 6 },
                    { 34, 7, 6 },
                    { 35, 13, 6 },
                    { 36, 15, 6 },
                    { 37, 26, 6 },
                    { 38, 1, 7 },
                    { 39, 3, 7 },
                    { 40, 6, 7 },
                    { 41, 8, 7 },
                    { 42, 9, 7 },
                    { 43, 16, 7 },
                    { 44, 1, 8 },
                    { 45, 3, 8 },
                    { 46, 4, 8 },
                    { 47, 6, 8 },
                    { 48, 10, 8 },
                    { 49, 16, 8 },
                    { 50, 1, 9 },
                    { 51, 3, 9 },
                    { 52, 6, 9 },
                    { 53, 7, 9 },
                    { 54, 15, 9 },
                    { 55, 26, 9 },
                    { 56, 1, 10 },
                    { 57, 3, 10 },
                    { 58, 6, 10 },
                    { 59, 7, 10 },
                    { 60, 23, 10 },
                    { 61, 27, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminResponses_RequestId",
                table: "AdminResponses",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminResponses_userId",
                table: "AdminResponses",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttachedDocuments_RequestId",
                table: "AttachedDocuments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FiledName",
                table: "Fields",
                column: "FiledName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RequestId",
                table: "Payments",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceId",
                table: "Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredDocuments_FileName",
                table: "RequiredDocuments",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequiredDocuments_ServiceId",
                table: "RequiredDocuments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceData_FieldId",
                table: "ServiceData",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceData_RequestId",
                table: "ServiceData",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFields_FieldId",
                table: "ServiceFields",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFields_ServiceId",
                table: "ServiceFields",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceDescription",
                table: "Services",
                column: "ServiceDescription",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceName",
                table: "Services",
                column: "ServiceName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminResponses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttachedDocuments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "RequiredDocuments");

            migrationBuilder.DropTable(
                name: "ServiceData");

            migrationBuilder.DropTable(
                name: "ServiceFields");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
