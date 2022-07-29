using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.SqlServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                name: "EvaluationTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertServiceId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluationTitleId = table.Column<int>(type: "int", nullable: false),
                    PastWorkId = table.Column<int>(type: "int", nullable: false),
                    ExpertServiceId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluations_EvaluationTitles_EvaluationTitleId",
                        column: x => x.EvaluationTitleId,
                        principalTable: "EvaluationTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ImageFileId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpertServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpertServices_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PastWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertServiceId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: true),
                    ComplitionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PastWorks_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PastWorks_ExpertServices_ExpertServiceId",
                        column: x => x.ExpertServiceId,
                        principalTable: "ExpertServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertServiceId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    NameWithExtention = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_ExpertServices_ExpertServiceId",
                        column: x => x.ExpertServiceId,
                        principalTable: "ExpertServices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Files_FileTypes_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentServiceId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: true),
                    ImageFileId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Files_ImageFileId",
                        column: x => x.ImageFileId,
                        principalTable: "Files",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Services_Services_ParentServiceId",
                        column: x => x.ParentServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    OrderStateId = table.Column<int>(type: "int", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStates_OrderStateId",
                        column: x => x.OrderStateId,
                        principalTable: "OrderStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequiredTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenders_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tenders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubmitDate", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, " ", "AppUser1@a.com", true, true, false, true, null, "AppUser1 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3407), false, "AppUser1username" },
                    { 2, 0, " ", "AppUser2@a.com", true, true, false, true, null, "AppUser2 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3465), false, "AppUser2username" },
                    { 3, 0, " ", "AppUser3@a.com", true, true, false, true, null, "AppUser3 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3477), false, "AppUser3username" },
                    { 4, 0, " ", "AppUser4@a.com", true, true, false, true, null, "AppUser4 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3488), false, "AppUser4username" },
                    { 5, 0, " ", "AppUser5@a.com", true, true, false, true, null, "AppUser5 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3498), false, "AppUser5username" },
                    { 6, 0, " ", "AppUser6@a.com", true, true, false, true, null, "AppUser6 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3508), false, "AppUser6username" },
                    { 7, 0, " ", "AppUser7@a.com", true, true, false, true, null, "AppUser7 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3533), false, "AppUser7username" },
                    { 8, 0, " ", "AppUser8@a.com", true, true, false, true, null, "AppUser8 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3545), false, "AppUser8username" },
                    { 9, 0, " ", "AppUser9@a.com", true, true, false, true, null, "AppUser9 ", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3555), false, "AppUser9username" },
                    { 10, 0, " ", "AppUser10@a.com", true, true, false, true, null, "AppUser10", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3566), false, "AppUser10username" },
                    { 11, 0, " ", "AppUser11@a.com", true, true, false, true, null, "AppUser11", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3577), false, "AppUser11username" },
                    { 12, 0, " ", "AppUser12@a.com", true, true, false, true, null, "AppUser12", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3587), false, "AppUser12username" },
                    { 13, 0, " ", "AppUser13@a.com", true, true, false, true, null, "AppUser13", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3597), false, "AppUser13username" },
                    { 14, 0, " ", "AppUser14@a.com", true, true, false, true, null, "AppUser14", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3608), false, "AppUser14username" },
                    { 15, 0, " ", "AppUser15@a.com", true, true, false, true, null, "AppUser15", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3623), false, "AppUser15username" },
                    { 16, 0, " ", "AppUser16@a.com", true, true, false, true, null, "AppUser16", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3633), false, "AppUser16username" },
                    { 17, 0, " ", "AppUser17@a.com", true, true, false, true, null, "AppUser17", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3644), false, "AppUser17username" },
                    { 18, 0, " ", "AppUser18@a.com", true, true, false, true, null, "AppUser18", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3655), false, "AppUser18username" },
                    { 19, 0, " ", "AppUser19@a.com", true, true, false, true, null, "AppUser19", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3665), false, "AppUser19username" },
                    { 20, 0, " ", "AppUser20@a.com", true, true, false, true, null, "AppUser20", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3676), false, "AppUser20username" },
                    { 21, 0, " ", "AppUser21@a.com", true, true, false, true, null, "AppUser21", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3686), false, "AppUser21username" },
                    { 22, 0, " ", "AppUser22@a.com", true, true, false, true, null, "AppUser22", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3696), false, "AppUser22username" },
                    { 23, 0, " ", "AppUser23@a.com", true, true, false, true, null, "AppUser23", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3710), false, "AppUser23username" },
                    { 24, 0, " ", "AppUser24@a.com", true, true, false, true, null, "AppUser24", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3722), false, "AppUser24username" },
                    { 25, 0, " ", "AppUser25@a.com", true, true, false, true, null, "AppUser25", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3732), false, "AppUser25username" },
                    { 26, 0, " ", "AppUser26@a.com", true, true, false, true, null, "AppUser26", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3753), false, "AppUser26username" },
                    { 27, 0, " ", "AppUser27@a.com", true, true, false, true, null, "AppUser27", null, null, "123", "09123456789", true, " ", new DateTime(2022, 7, 22, 20, 28, 13, 308, DateTimeKind.Local).AddTicks(3763), false, "AppUser27username" }
                });

            migrationBuilder.InsertData(
                table: "EvaluationTitles",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 1, false, "کیفیت" });

            migrationBuilder.InsertData(
                table: "FileTypes",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 1, false, "Image" });

            migrationBuilder.InsertData(
                table: "OrderStates",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "در حال بررسی" },
                    { 2, false, "منتظر پیشنهاد متخصص" },
                    { 3, false, "منتظر انتخاب متخصص" },
                    { 4, false, "منتظر آمدن متخصص" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "AppUserId" },
                values: new object[,]
                {
                    { 1, "", 10 },
                    { 2, "", 11 },
                    { 3, "", 12 },
                    { 4, "", 13 },
                    { 5, "", 14 },
                    { 6, "", 15 },
                    { 7, "", 16 },
                    { 8, "", 17 },
                    { 9, "", 18 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "CreationDate", "Description", "ExpertServiceId", "FileTypeId", "IsDeleted", "NameWithExtention", "ServiceId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3063), "توضیح فایل 01", null, 1, false, "File01.jpg", null },
                    { 2, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3096), "توضیح فایل 02", null, 1, false, "File02.jpg", null },
                    { 3, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3102), "توضیح فایل 03", null, 1, false, "File03.jpg", null },
                    { 4, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3107), "توضیح فایل 04", null, 1, false, "File04.jpg", null },
                    { 5, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3377), "توضیح فایل 05", null, 1, false, "File05.jpg", null },
                    { 6, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3382), "توضیح فایل 06", null, 1, false, "File06.jpg", null },
                    { 7, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3388), "توضیح فایل 07", null, 1, false, "File07.jpg", null },
                    { 8, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3392), "توضیح فایل 08", null, 1, false, "File08.jpg", null },
                    { 9, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3397), "توضیح فایل 09", null, 1, false, "File09.jpg", null },
                    { 10, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3402), "توضیح فایل 10", null, 1, false, "File10.jpg", null },
                    { 11, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3407), "توضیح فایل 11", null, 1, false, "File11.jpg", null },
                    { 12, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3412), "توضیح فایل 12", null, 1, false, "File12.jpg", null },
                    { 13, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3417), "توضیح فایل 13", null, 1, false, "File13.jpg", null },
                    { 14, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3422), "توضیح فایل 14", null, 1, false, "File14.jpg", null },
                    { 15, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3426), "توضیح فایل 15", null, 1, false, "File15.jpg", null },
                    { 16, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3431), "توضیح فایل 16", null, 1, false, "File16.jpg", null },
                    { 17, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3437), "توضیح فایل 17", null, 1, false, "File17.jpg", null },
                    { 18, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3441), "توضیح فایل 18", null, 1, false, "File18.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "Address", "AppUserId", "ImageFileId" },
                values: new object[,]
                {
                    { 1, "آدرس متخصص 1", 1, 1 },
                    { 2, "آدرس متخصص 2", 2, 2 },
                    { 3, "آدرس متخصص 3", 3, 3 },
                    { 4, "آدرس متخصص 4", 4, 4 },
                    { 5, "آدرس متخصص 5", 5, 5 },
                    { 6, "آدرس متخصص 6", 6, 6 },
                    { 7, "آدرس متخصص 7", 7, 7 },
                    { 8, "آدرس متخصص 8", 8, 8 },
                    { 9, "آدرس متخصص 9", 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Description", "ImageFileId", "IsActive", "IsDeleted", "Name", "ParentServiceId", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3011), "توضیح سرویس 1", 10, true, false, "سرویس 1", null, 100000L },
                    { 2, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3044), "توضیح سرویس 2", 11, true, false, "سرویس 2", null, 100000L }
                });

            migrationBuilder.InsertData(
                table: "ExpertServices",
                columns: new[] { "Id", "CreationDate", "ExpertId", "IsActive", "IsDeleted", "ServiceId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8748), 1, true, false, 1 },
                    { 2, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8779), 2, true, false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsDeleted", "OrderStateId", "RegisterDate", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(327), 1 },
                    { 2, 2, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(351), 2 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreationDate", "Description", "ImageFileId", "IsActive", "IsDeleted", "Name", "ParentServiceId", "Price" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3050), "توضیح سرویس 3", 12, true, false, "سرویس 3", 1, 100000L },
                    { 4, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3055), "توضیح سرویس 4", 13, true, false, "سرویس 4", 1, 100000L },
                    { 5, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3060), "توضیح سرویس 5", 14, true, false, "سرویس 5", 1, 100000L },
                    { 6, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3065), "توضیح سرویس 6", 15, true, false, "سرویس 6", 2, 100000L },
                    { 7, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3069), "توضیح سرویس 7", 16, true, false, "سرویس 7", 2, 100000L },
                    { 8, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3088), "توضیح سرویس 8", 17, true, false, "سرویس 8", 2, 100000L },
                    { 9, new DateTime(2022, 7, 22, 20, 28, 13, 316, DateTimeKind.Local).AddTicks(3092), "توضیح سرویس 9", 18, true, false, "سرویس 9", 2, 100000L }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CustomerId", "DislikeCount", "ExpertServiceId", "IsConfirmed", "LikeCount", "SubmitDate", "Text", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4290), "متن", "کامنت مشتری 1 برای سرویس-متخصص شماره 1" },
                    { 2, 2, 1, 2, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4311), "متن", "کامنت مشتری 2 برای سرویس-متخصص شماره 2" }
                });

            migrationBuilder.InsertData(
                table: "ExpertServices",
                columns: new[] { "Id", "CreationDate", "ExpertId", "IsActive", "IsDeleted", "ServiceId" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8785), 3, true, false, 3 },
                    { 4, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8791), 4, true, false, 4 },
                    { 5, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8795), 5, true, false, 5 },
                    { 6, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8799), 6, true, false, 6 },
                    { 7, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8805), 7, true, false, 7 },
                    { 8, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8809), 8, true, false, 8 },
                    { 9, new DateTime(2022, 7, 22, 20, 28, 13, 309, DateTimeKind.Local).AddTicks(8812), 9, true, false, 9 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "CreationDate", "Description", "ExpertServiceId", "FileTypeId", "IsDeleted", "NameWithExtention", "ServiceId" },
                values: new object[,]
                {
                    { 19, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3446), "توضیح فایل 19", 1, 1, false, "File19.jpg", null },
                    { 20, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3453), "توضیح فایل 20", 2, 1, false, "File20.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "IsDeleted", "OrderStateId", "RegisterDate", "ServiceId" },
                values: new object[,]
                {
                    { 3, 3, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(355), 3 },
                    { 4, 4, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(359), 4 },
                    { 5, 5, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(363), 5 },
                    { 6, 6, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(367), 6 },
                    { 7, 7, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(370), 7 },
                    { 8, 8, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(374), 8 },
                    { 9, 9, false, 1, new DateTime(2022, 7, 22, 20, 28, 13, 317, DateTimeKind.Local).AddTicks(378), 9 }
                });

            migrationBuilder.InsertData(
                table: "PastWorks",
                columns: new[] { "Id", "ComplitionDate", "CustomerId", "ExpertServiceId", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2288), 1, 1, false, 100000L },
                    { 2, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2327), 2, 2, false, 200000L }
                });

            migrationBuilder.InsertData(
                table: "Tenders",
                columns: new[] { "Id", "ExpertId", "OrderId", "Price", "RegisterDate", "RequiredTime", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 1, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7685), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7717) },
                    { 2, 2, 2, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7725), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7730) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CustomerId", "DislikeCount", "ExpertServiceId", "IsConfirmed", "LikeCount", "SubmitDate", "Text", "Title" },
                values: new object[,]
                {
                    { 3, 3, 1, 3, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4324), "متن", "کامنت مشتری 3 برای سرویس-متخصص شماره 3" },
                    { 4, 4, 1, 4, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4330), "متن", "کامنت مشتری 4 برای سرویس-متخصص شماره 4" },
                    { 5, 5, 1, 5, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4335), "متن", "کامنت مشتری 5 برای سرویس-متخصص شماره 5" },
                    { 6, 6, 1, 6, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4340), "متن", "کامنت مشتری 6 برای سرویس-متخصص شماره 6" },
                    { 7, 7, 1, 7, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4346), "متن", "کامنت مشتری 7 برای سرویس-متخصص شماره 7" },
                    { 8, 8, 1, 8, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4351), "متن", "کامنت مشتری 8 برای سرویس-متخصص شماره 8" },
                    { 9, 9, 1, 9, true, 1, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(4356), "متن", "کامنت مشتری 9 برای سرویس-متخصص شماره 9" }
                });

            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "EvaluationTitleId", "ExpertServiceId", "PastWorkId", "Score" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, (short)2 },
                    { 2, 1, 2, 2, (short)2 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "CreationDate", "Description", "ExpertServiceId", "FileTypeId", "IsDeleted", "NameWithExtention", "ServiceId" },
                values: new object[,]
                {
                    { 21, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3458), "توضیح فایل 21", 3, 1, false, "File21.jpg", null },
                    { 22, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3464), "توضیح فایل 22", 4, 1, false, "File22.jpg", null },
                    { 23, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3470), "توضیح فایل 23", 5, 1, false, "File23.jpg", null },
                    { 24, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3475), "توضیح فایل 24", 6, 1, false, "File24.jpg", null },
                    { 25, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3480), "توضیح فایل 25", 7, 1, false, "File25.jpg", null },
                    { 26, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3484), "توضیح فایل 26", 8, 1, false, "File26.jpg", null },
                    { 27, new DateTime(2022, 7, 22, 20, 28, 13, 310, DateTimeKind.Local).AddTicks(3490), "توضیح فایل 27", 9, 1, false, "File27.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "PastWorks",
                columns: new[] { "Id", "ComplitionDate", "CustomerId", "ExpertServiceId", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2333), 3, 3, false, 300000L },
                    { 4, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2339), 4, 4, false, 400000L },
                    { 5, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2345), 5, 5, false, 500000L },
                    { 6, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2350), 6, 6, false, 600000L },
                    { 7, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2356), 7, 7, false, 700000L },
                    { 8, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2362), 8, 8, false, 800000L },
                    { 9, new DateTime(2022, 7, 20, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(2368), 9, 9, false, 900000L }
                });

            migrationBuilder.InsertData(
                table: "Tenders",
                columns: new[] { "Id", "ExpertId", "OrderId", "Price", "RegisterDate", "RequiredTime", "StartDate" },
                values: new object[,]
                {
                    { 3, 3, 3, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7736), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7740) },
                    { 4, 4, 4, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7746), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7750) },
                    { 5, 5, 5, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7755), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7760) },
                    { 6, 6, 6, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7765), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7769) },
                    { 7, 7, 7, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7774), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7778) },
                    { 8, 8, 8, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7784), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7788) },
                    { 9, 9, 9, 100000L, new DateTime(2022, 7, 22, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7794), new TimeSpan(0, 3, 0, 0, 0), new DateTime(2022, 7, 23, 20, 28, 13, 311, DateTimeKind.Local).AddTicks(7798) }
                });

            migrationBuilder.InsertData(
                table: "Evaluations",
                columns: new[] { "Id", "EvaluationTitleId", "ExpertServiceId", "PastWorkId", "Score" },
                values: new object[,]
                {
                    { 3, 1, 3, 3, (short)2 },
                    { 4, 1, 4, 4, (short)2 },
                    { 5, 1, 5, 5, (short)2 },
                    { 6, 1, 6, 6, (short)2 },
                    { 7, 1, 7, 7, (short)2 },
                    { 8, 1, 8, 8, (short)2 },
                    { 9, 1, 9, 9, (short)2 }
                });

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
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExpertServiceId",
                table: "Comments",
                column: "ExpertServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_EvaluationTitleId",
                table: "Evaluations",
                column: "EvaluationTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_ExpertServiceId",
                table: "Evaluations",
                column: "ExpertServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_PastWorkId",
                table: "Evaluations",
                column: "PastWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_AppUserId",
                table: "Experts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_ImageFileId",
                table: "Experts",
                column: "ImageFileId",
                unique: true,
                filter: "[ImageFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertServices_ExpertId",
                table: "ExpertServices",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertServices_ServiceId",
                table: "ExpertServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ExpertServiceId",
                table: "Files",
                column: "ExpertServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileTypeId",
                table: "Files",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ServiceId",
                table: "Files",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStateId",
                table: "Orders",
                column: "OrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServiceId",
                table: "Orders",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PastWorks_CustomerId",
                table: "PastWorks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PastWorks_ExpertServiceId",
                table: "PastWorks",
                column: "ExpertServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ImageFileId",
                table: "Services",
                column: "ImageFileId",
                unique: true,
                filter: "[ImageFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ParentServiceId",
                table: "Services",
                column: "ParentServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_ExpertId",
                table: "Tenders",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_OrderId",
                table: "Tenders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ExpertServices_ExpertServiceId",
                table: "Comments",
                column: "ExpertServiceId",
                principalTable: "ExpertServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_ExpertServices_ExpertServiceId",
                table: "Evaluations",
                column: "ExpertServiceId",
                principalTable: "ExpertServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluations_PastWorks_PastWorkId",
                table: "Evaluations",
                column: "PastWorkId",
                principalTable: "PastWorks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Experts_Files_ImageFileId",
                table: "Experts",
                column: "ImageFileId",
                principalTable: "Files",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertServices_Services_ServiceId",
                table: "ExpertServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Services_ServiceId",
                table: "Files",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experts_AspNetUsers_AppUserId",
                table: "Experts");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_ExpertServices_ExpertServiceId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Files_ImageFileId",
                table: "Services");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EvaluationTitles");

            migrationBuilder.DropTable(
                name: "PastWorks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OrderStates");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExpertServices");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
