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
                    FieldName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false),
                    HtmlType = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                columns: new[] { "Id", "Description", "FieldName", "HtmlType" },
                values: new object[,]
                {
                    { 1, "أدخل رقم جواز السفر الحالي.", "رقم جواز السفر الحالي", "text" },
                    { 2, "أدخل رقم جواز السفر السابق (إن وجد).", "رقم جواز السفر السابق", "text" },
                    { 3, "أدخل تاريخ إصدار الجواز الحالي.", "تاريخ إصدار الجواز", "date" },
                    { 4, "أدخل تاريخ انتهاء الجواز الحالي.", "تاريخ انتهاء الجواز", "date" },
                    { 5, "أدخل مكان إصدار الجواز.", "جهة إصدار الجواز", "text" },
                    { 6, "أدخل اسمك باللغة الإنجليزية كما في الجواز.", "الاسم باللغة الإنجليزية", "text" },
                    { 7, "أدخل رقم إيصال دفع رسوم التجديد.", "رقم تأكيد الدفع", "text" },
                    { 8, "أدخل جنسك (ذكر/أنثى).", "الجنس", "text" },
                    { 9, "أدخل مهنتك الحالية.", "المهنة", "text" },
                    { 10, "أدخل رقم الموعد لاستلام الجواز.", "رقم الموعد", "text" },
                    { 11, "أدخل نوع الرخصة (خاصة/تجارية).", "نوع رخصة القيادة", "text" },
                    { 12, "أدخل رقم ملفك المروري (إن وجد).", "رقم الملف المروري", "text" },
                    { 13, "أدخل تاريخ اجتياز اختبار القيادة.", "تاريخ اجتياز الاختبار", "date" },
                    { 14, "أدخل اسم مدرسة تدريب القيادة.", "اسم مدرسة القيادة", "text" },
                    { 15, "أدخل رقم شهادة اللياقة الطبية.", "رقم شهادة اللياقة", "text" },
                    { 16, "أدخل المحافظة التي ستصدر منها الرخصة.", "المحافظة المصدرة", "text" },
                    { 17, "أدخل تاريخ تقديم طلب الرخصة.", "تاريخ التقديم للرخصة", "date" },
                    { 18, "أدخل رقم إيصال دفع رسوم الرخصة.", "رقم إيصال الرسوم", "text" },
                    { 19, "أدخل نوع المركبة (سيارة/دراجة).", "نوع المركبة المطلوبة", "text" },
                    { 20, "أدخل حالة رخصتك السابقة (إن وجدت).", "حالة الرخصة السابقة", "text" },
                    { 21, "أدخل رقم لوحة المركبة.", "رقم لوحة المركبة", "text" },
                    { 22, "أدخل رقم الشاسيه الخاص بالمركبة.", "رقم الشاسيه", "text" },
                    { 23, "أدخل رقم الموتور الخاص بالمركبة.", "رقم الموتور", "text" },
                    { 24, "أدخل نوع المركبة (سيارة/شاحنة).", "نوع المركبة", "text" },
                    { 25, "أدخل سنة تصنيع المركبة.", "سنة الصنع", "number" },
                    { 26, "أدخل رقم وثيقة التأمين على المركبة.", "رقم التأمين", "text" },
                    { 27, "أدخل تاريخ تسجيل المركبة.", "تاريخ التسجيل", "date" },
                    { 28, "أدخل اسم الوكيل أو البائع.", "اسم الوكيل", "text" },
                    { 29, "أدخل رقم فاتورة شراء المركبة.", "رقم الفاتورة", "text" },
                    { 30, "أدخل لون المركبة.", "لون المركبة", "text" },
                    { 31, "أدخل اسم الزوج الكامل.", "اسم الزوج", "text" },
                    { 32, "أدخل اسم الزوجة الكامل.", "اسم الزوجة", "text" },
                    { 33, "أدخل تاريخ عقد الزواج.", "تاريخ الزواج", "date" },
                    { 34, "أدخل مكان عقد الزواج.", "مكان الزواج", "text" },
                    { 35, "أدخل رقم عقد الزواج.", "رقم عقد الزواج", "text" },
                    { 36, "أدخل اسم المأذون الذي أجرى العقد.", "اسم المأذون", "text" },
                    { 37, "أدخل عدد الشهود على العقد.", "عدد الشهود", "number" },
                    { 38, "أدخل تاريخ تسجيل العقد رسميًا.", "تاريخ التسجيل", "date" },
                    { 39, "أدخل رقم إيصال دفع رسوم الشهادة.", "رقم إيصال الرسوم", "text" },
                    { 40, "أدخل محل إقامة الزوجين.", "محل إقامة الزوجين", "text" },
                    { 41, "أدخل اسم المولود الكامل.", "اسم المولود", "text" },
                    { 42, "أدخل تاريخ ميلاد المولود.", "تاريخ الميلاد", "date" },
                    { 43, "أدخل مكان ميلاد المولود.", "محل الميلاد", "text" },
                    { 44, "أدخل اسم المستشفى أو مكان الولادة.", "اسم المستشفى", "text" },
                    { 45, "أدخل رقم تسجيل الميلاد.", "رقم تسجيل الميلاد", "text" },
                    { 46, "أدخل جنس المولود (ذكر/أنثى).", "جنس المولود", "text" },
                    { 47, "أدخل اسم الطبيب المشرف على الولادة.", "اسم الطبيب", "text" },
                    { 48, "أدخل تاريخ إصدار الشهادة.", "تاريخ الإصدار", "date" },
                    { 49, "أدخل رقم إيصال دفع رسوم الشهادة.", "رقم إيصال الرسوم", "text" },
                    { 50, "أدخل اسم مقدم طلب الشهادة.", "اسم مقدم الطلب", "text" },
                    { 51, "أدخل رقم شهادة الميلاد.", "رقم شهادة الميلاد", "text" },
                    { 52, "أدخل تاريخ تقديم طلب البطاقة.", "تاريخ تقديم الطلب", "date" },
                    { 53, "أدخل رقم الموعد لاستلام البطاقة.", "رقم الموعد", "text" },
                    { 54, "أدخل مكان إصدار البطاقة.", "محل الإصدار", "text" },
                    { 55, "أدخل رقم تسجيل البصمة (إن وجد).", "رقم البصمة", "text" },
                    { 56, "أدخل اسم الأب الكامل.", "اسم الأب", "text" },
                    { 57, "أدخل اسم الأم الكامل.", "اسم الأم", "text" },
                    { 58, "أدخل جنسك (ذكر/أنثى).", "الجنس", "text" },
                    { 59, "أدخل رقم إيصال دفع رسوم البطاقة.", "رقم إيصال الرسوم", "text" },
                    { 60, "أدخل حالتك الاجتماعية.", "الحالة الاجتماعية", "text" },
                    { 61, "أدخل اسم النشاط التجاري.", "اسم النشاط التجاري", "text" },
                    { 62, "أدخل نوع النشاط (تجاري/صناعي).", "نوع النشاط", "text" },
                    { 63, "أدخل قيمة رأس المال المسجل.", "رأس المال", "number" },
                    { 64, "أدخل رقم التسجيل الضريبي.", "رقم التسجيل الضريبي", "text" },
                    { 65, "أدخل عدد الموظفين في النشاط.", "عدد الموظفين", "number" },
                    { 66, "أدخل تاريخ بدء النشاط التجاري.", "تاريخ بدء النشاط", "date" },
                    { 67, "أدخل عنوان المقر التجاري.", "عنوان المقر", "text" },
                    { 68, "أدخل رقم السجل التجاري (إن وجد).", "رقم السجل التجاري", "text" },
                    { 69, "أدخل اسم مالك النشاط.", "اسم المالك", "text" },
                    { 70, "أدخل رقم إيصال دفع رسوم التسجيل.", "رقم إيصال الرسوم", "text" },
                    { 71, "أدخل رقم جواز السفر.", "رقم جواز السفر", "text" },
                    { 72, "أدخل جنسيتك.", "الجنسية", "text" },
                    { 73, "أدخل اسم جهة العمل في مصر.", "اسم جهة العمل", "text" },
                    { 74, "أدخل عنوان جهة العمل.", "عنوان جهة العمل", "text" },
                    { 75, "أدخل مدة عقد العمل (بالأشهر).", "مدة العقد", "number" },
                    { 76, "أدخل أعلى مؤهل دراسي حصلت عليه.", "المؤهل الدراسي", "text" },
                    { 77, "أدخل تاريخ بدء العمل.", "تاريخ بدء العمل", "date" },
                    { 78, "أدخل رقم التأشيرة (إن وجد).", "رقم التأشيرة", "text" },
                    { 79, "أدخل اسم المسؤول في جهة العمل.", "اسم المسؤول", "text" },
                    { 80, "أدخل رقم إيصال دفع رسوم التصريح.", "رقم إيصال الرسوم", "text" },
                    { 81, "أدخل رقم تصريح الإقامة الحالي.", "رقم تصريح الإقامة الحالي", "text" },
                    { 82, "أدخل تاريخ انتهاء الإقامة الحالية.", "تاريخ انتهاء الإقامة", "date" },
                    { 83, "أدخل سبب الإقامة (عمل/دراسة).", "سبب الإقامة", "text" },
                    { 84, "أدخل مدة الإقامة المطلوبة (بالأشهر).", "مدة الإقامة المطلوبة", "number" },
                    { 85, "أدخل اسم الكفيل (إن وجد).", "اسم الكفيل", "text" },
                    { 86, "أدخل عنوان السكن في مصر.", "عنوان السكن", "text" },
                    { 87, "أدخل رقم جواز السفر.", "رقم جواز السفر", "text" },
                    { 88, "أدخل تاريخ تقديم طلب التجديد.", "تاريخ التقديم", "date" },
                    { 89, "أدخل رقم إيصال دفع رسوم التجديد.", "رقم إيصال الرسوم", "text" },
                    { 90, "أدخل جنسيتك.", "الجنسية", "text" },
                    { 91, "أدخل نوع الضريبة (دخل/قيمة مضافة).", "نوع الضريبة", "text" },
                    { 92, "أدخل تقدير دخلك السنوي.", "الدخل السنوي", "number" },
                    { 93, "أدخل رقم حسابك البنكي.", "رقم الحساب البنكي", "text" },
                    { 94, "أدخل اسم النشاط التجاري.", "اسم النشاط التجاري", "text" },
                    { 95, "أدخل رقم السجل التجاري.", "رقم السجل التجاري", "text" },
                    { 96, "أدخل تاريخ التسجيل الضريبي.", "تاريخ التسجيل", "date" },
                    { 97, "أدخل عنوان النشاط الضريبي.", "عنوان النشاط", "text" },
                    { 98, "أدخل رقم إيصال دفع رسوم التسجيل.", "رقم إيصال الرسوم", "text" },
                    { 99, "أدخل اسم المحاسب القانوني (إن وجد).", "اسم المحاسب", "text" },
                    { 100, "أدخل رقم التسجيل الضريبي السابق (إن وجد).", "رقم التسجيل السابق", "text" },
                    { 101, "أدخل اسم المتوفى الكامل.", "اسم المتوفى", "text" },
                    { 102, "أدخل تاريخ الوفاة.", "تاريخ الوفاة", "date" },
                    { 103, "أدخل مكان الوفاة.", "مكان الوفاة", "text" },
                    { 104, "أدخل رقم تسجيل الوفاة.", "رقم تسجيل الوفاة", "text" },
                    { 105, "أدخل علاقتك بالمتوفى.", "العلاقة بالمتوفى", "text" },
                    { 106, "أدخل اسم المقبرة أو مكان الدفن.", "اسم المقبرة", "text" },
                    { 107, "أدخل تاريخ الدفن.", "تاريخ الدفن", "date" },
                    { 108, "أدخل رقم إيصال دفع رسوم الشهادة.", "رقم إيصال الرسوم", "text" },
                    { 109, "أدخل اسم مقدم الطلب.", "اسم مقدم الطلب", "text" },
                    { 110, "أدخل سبب الوفاة (إن وجد).", "سبب الوفاة", "text" },
                    { 111, "أدخل رقم السجل التجاري الحالي.", "رقم السجل التجاري الحالي", "text" },
                    { 112, "أدخل تاريخ انتهاء السجل الحالي.", "تاريخ انتهاء السجل", "date" },
                    { 113, "أدخل قيمة رأس المال المحدث.", "رأس المال المحدث", "number" },
                    { 114, "أدخل عدد الموظفين الحالي.", "عدد الموظفين المحدث", "number" },
                    { 115, "أدخل اسم النشاط التجاري.", "اسم النشاط التجاري", "text" },
                    { 116, "أدخل عنوان المقر التجاري المحدث.", "عنوان المقر المحدث", "text" },
                    { 117, "أدخل رقم التسجيل الضريبي.", "رقم التسجيل الضريبي", "text" },
                    { 118, "أدخل تاريخ تقديم طلب التجديد.", "تاريخ التجديد", "date" },
                    { 119, "أدخل رقم إيصال دفع رسوم التجديد.", "رقم إيصال الرسوم", "text" },
                    { 120, "أدخل اسم مالك النشاط.", "اسم المالك", "text" },
                    { 121, "أدخل الغرض من استخراج الشهادة.", "الغرض من الشهادة", "text" },
                    { 122, "أدخل تاريخ تقديم طلب الشهادة.", "تاريخ التقديم", "date" },
                    { 123, "أدخل مكان إصدار الشهادة.", "محل الإصدار", "text" },
                    { 124, "أدخل رقم الموعد لاستلام الشهادة.", "رقم الموعد", "text" },
                    { 125, "أدخل اسم الأب الكامل.", "اسم الأب", "text" },
                    { 126, "أدخل اسم الأم الكامل.", "اسم الأم", "text" },
                    { 127, "أدخل رقم إيصال دفع رسوم الشهادة.", "رقم إيصال الرسوم", "text" },
                    { 128, "أدخل جنسك (ذكر/أنثى).", "الجنس", "text" },
                    { 129, "أدخل تاريخ ميلادك.", "تاريخ الميلاد", "date" },
                    { 130, "أدخل مكان ميلادك.", "محل الميلاد", "text" },
                    { 131, "أدخل عنوان العقار بالتفصيل.", "عنوان العقار", "text" },
                    { 132, "أدخل رقم عقد الملكية.", "رقم العقد", "text" },
                    { 133, "أدخل نوع العقار (شقة/أرض).", "نوع العقار", "text" },
                    { 134, "أدخل مساحة العقار بالمتر المربع.", "مساحة العقار", "number" },
                    { 135, "أدخل تاريخ شراء العقار.", "تاريخ الشراء", "date" },
                    { 136, "أدخل اسم البائع في العقد.", "اسم البائع", "text" },
                    { 137, "أدخل رقم الخريطة المساحية.", "رقم الخريطة المساحية", "text" },
                    { 138, "أدخل رقم إيصال دفع رسوم التسجيل.", "رقم إيصال الرسوم", "text" },
                    { 139, "أدخل اسم مالك العقار.", "اسم المالك", "text" },
                    { 140, "أدخل القيمة المالية للعقار.", "قيمة العقار", "number" },
                    { 141, "أدخل عدد أفراد الأسرة.", "عدد أفراد الأسرة", "number" },
                    { 142, "أدخل تقدير دخلك الشهري.", "الدخل الشهري", "number" },
                    { 143, "أدخل رقم بطاقة التموين (إن وجد).", "رقم بطاقة التموين الحالية", "text" },
                    { 144, "أدخل اسم المخبز المفضل للتوزيع.", "اسم المخبز المفضل", "text" },
                    { 145, "أدخل تاريخ تقديم طلب الدعم.", "تاريخ التقديم", "date" },
                    { 146, "أدخل رقم إيصال دفع رسوم التقديم.", "رقم إيصال الرسوم", "text" },
                    { 147, "أدخل اسم مقدم الطلب.", "اسم مقدم الطلب", "text" },
                    { 148, "أدخل حالتك الاجتماعية.", "الحالة الاجتماعية", "text" },
                    { 149, "أدخل عنوان السكن الحالي.", "عنوان السكن", "text" },
                    { 150, "أدخل رقم الحساب البنكي (إن وجد).", "رقم الحساب البنكي", "text" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ContactInfo", "Fee", "IsAvailable", "ProcessingTime", "ServiceDescription", "ServiceName" },
                values: new object[,]
                {
                    { 1, "passports@moe.gov.eg", 1000.00m, true, "5 أيام عمل", "تجديد جواز السفر المصري بسهولة وسرعة.", "تجديد جواز السفر" },
                    { 2, "traffic@moi.gov.eg", 300.00m, true, "7 أيام عمل", "التقديم للحصول على رخصة قيادة جديدة.", "إصدار رخصة قيادة" },
                    { 3, "vehicles@moi.gov.eg", 500.00m, true, "3 أيام عمل", "تسجيل مركبتك لدى إدارة المرور.", "تسجيل مركبة" },
                    { 4, "civil@moj.gov.eg", 150.00m, true, "4 أيام عمل", "طلب شهادة زواج رسمية من السجل المدني.", "إصدار شهادة زواج" },
                    { 5, "birth@moj.gov.eg", 100.00m, true, "2 يوم عمل", "استخراج شهادة ميلاد رسمية.", "إصدار شهادة ميلاد" },
                    { 6, "id@moe.gov.eg", 150.00m, true, "6 أيام عمل", "طلب إصدار بطاقة رقم قومي جديدة.", "التقديم لبطاقة الرقم القومي" },
                    { 7, "commerce@mit.gov.eg", 2000.00m, true, "10 أيام عمل", "تسجيل عملك التجاري بشكل قانوني.", "تسجيل رخصة تجارية" },
                    { 8, "labor@mol.gov.eg", 1500.00m, true, "8 أيام عمل", "التقديم لتصريح عمل للأجانب.", "إصدار تصريح عمل" },
                    { 9, "immigration@moe.gov.eg", 1200.00m, true, "7 أيام عمل", "تجديد تصريح الإقامة للمقيمين.", "تجديد تصريح الإقامة" },
                    { 10, "tax@mof.gov.eg", 400.00m, true, "5 أيام عمل", "التسجيل لأغراض الضرائب.", "التسجيل الضريبي" },
                    { 11, "death@moj.gov.eg", 100.00m, true, "2 يوم عمل", "طلب شهادة وفاة رسمية.", "استخراج شهادة وفاة" },
                    { 12, "registry@mit.gov.eg", 1000.00m, true, "7 أيام عمل", "تجديد السجل التجاري للشركات.", "تجديد السجل التجاري" },
                    { 13, "cert@moi.gov.eg", 200.00m, true, "3 أيام عمل", "استخراج شهادة حسن سير وسلوك.", "إصدار شهادة حسن سير وسلوك" },
                    { 14, "property@moj.gov.eg", 1500.00m, true, "10 أيام عمل", "تسجيل ملكية عقار في الشهر العقاري.", "تسجيل عقار" },
                    { 15, "supply@moss.gov.eg", 50.00m, true, "5 أيام عمل", "التسجيل للحصول على بطاقة تموين.", "التقديم للحصول على دعم تمويني" }
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
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 11, 11, 2 },
                    { 12, 12, 2 },
                    { 13, 13, 2 },
                    { 14, 14, 2 },
                    { 15, 15, 2 },
                    { 16, 16, 2 },
                    { 17, 17, 2 },
                    { 18, 18, 2 },
                    { 19, 19, 2 },
                    { 20, 20, 2 },
                    { 21, 21, 3 },
                    { 22, 22, 3 },
                    { 23, 23, 3 },
                    { 24, 24, 3 },
                    { 25, 25, 3 },
                    { 26, 26, 3 },
                    { 27, 27, 3 },
                    { 28, 28, 3 },
                    { 29, 29, 3 },
                    { 30, 30, 3 },
                    { 31, 31, 4 },
                    { 32, 32, 4 },
                    { 33, 33, 4 },
                    { 34, 34, 4 },
                    { 35, 35, 4 },
                    { 36, 36, 4 },
                    { 37, 37, 4 },
                    { 38, 38, 4 },
                    { 39, 39, 4 },
                    { 40, 40, 4 },
                    { 41, 41, 5 },
                    { 42, 42, 5 },
                    { 43, 43, 5 },
                    { 44, 44, 5 },
                    { 45, 45, 5 },
                    { 46, 46, 5 },
                    { 47, 47, 5 },
                    { 48, 48, 5 },
                    { 49, 49, 5 },
                    { 50, 50, 5 },
                    { 51, 51, 6 },
                    { 52, 52, 6 },
                    { 53, 53, 6 },
                    { 54, 54, 6 },
                    { 55, 55, 6 },
                    { 56, 56, 6 },
                    { 57, 57, 6 },
                    { 58, 58, 6 },
                    { 59, 59, 6 },
                    { 60, 60, 6 },
                    { 61, 61, 7 },
                    { 62, 62, 7 },
                    { 63, 63, 7 },
                    { 64, 64, 7 },
                    { 65, 65, 7 },
                    { 66, 66, 7 },
                    { 67, 67, 7 },
                    { 68, 68, 7 },
                    { 69, 69, 7 },
                    { 70, 70, 7 },
                    { 71, 71, 8 },
                    { 72, 72, 8 },
                    { 73, 73, 8 },
                    { 74, 74, 8 },
                    { 75, 75, 8 },
                    { 76, 76, 8 },
                    { 77, 77, 8 },
                    { 78, 78, 8 },
                    { 79, 79, 8 },
                    { 80, 80, 8 },
                    { 81, 81, 9 },
                    { 82, 82, 9 },
                    { 83, 83, 9 },
                    { 84, 84, 9 },
                    { 85, 85, 9 },
                    { 86, 86, 9 },
                    { 87, 87, 9 },
                    { 88, 88, 9 },
                    { 89, 89, 9 },
                    { 90, 90, 9 },
                    { 91, 91, 10 },
                    { 92, 92, 10 },
                    { 93, 93, 10 },
                    { 94, 94, 10 },
                    { 95, 95, 10 },
                    { 96, 96, 10 },
                    { 97, 97, 10 },
                    { 98, 98, 10 },
                    { 99, 99, 10 },
                    { 100, 100, 10 },
                    { 101, 101, 11 },
                    { 102, 102, 11 },
                    { 103, 103, 11 },
                    { 104, 104, 11 },
                    { 105, 105, 11 },
                    { 106, 106, 11 },
                    { 107, 107, 11 },
                    { 108, 108, 11 },
                    { 109, 109, 11 },
                    { 110, 110, 11 },
                    { 111, 111, 12 },
                    { 112, 112, 12 },
                    { 113, 113, 12 },
                    { 114, 114, 12 },
                    { 115, 115, 12 },
                    { 116, 116, 12 },
                    { 117, 117, 12 },
                    { 118, 118, 12 },
                    { 119, 119, 12 },
                    { 120, 120, 12 },
                    { 121, 121, 13 },
                    { 122, 122, 13 },
                    { 123, 123, 13 },
                    { 124, 124, 13 },
                    { 125, 125, 13 },
                    { 126, 126, 13 },
                    { 127, 127, 13 },
                    { 128, 128, 13 },
                    { 129, 129, 13 },
                    { 130, 130, 13 },
                    { 131, 131, 14 },
                    { 132, 132, 14 },
                    { 133, 133, 14 },
                    { 134, 134, 14 },
                    { 135, 135, 14 },
                    { 136, 136, 14 },
                    { 137, 137, 14 },
                    { 138, 138, 14 },
                    { 139, 139, 14 },
                    { 140, 140, 14 },
                    { 141, 141, 15 },
                    { 142, 142, 15 },
                    { 143, 143, 15 },
                    { 144, 144, 15 },
                    { 145, 145, 15 },
                    { 146, 146, 15 },
                    { 147, 147, 15 },
                    { 148, 148, 15 },
                    { 149, 149, 15 },
                    { 150, 150, 15 }
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
