using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vemo.Infrastructure.Persistence.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AgeInMonth = table.Column<int>(type: "integer", nullable: false),
                    MaintenancePrice = table.Column<float>(type: "real", nullable: false),
                    MaintenanceServicePrice = table.Column<float>(type: "real", nullable: false),
                    VehicleType = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Read = table.Column<bool>(type: "boolean", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAuthInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Otp = table.Column<int>(type: "integer", nullable: true),
                    OtpExpires = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAuthInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OwnerName = table.Column<string>(type: "text", nullable: false),
                    PurchasingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LicensePlate = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePartConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NextMaintenance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehiclePartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePartConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePartConditions_VehicleParts_VehiclePartId",
                        column: x => x.VehiclePartId,
                        principalTable: "VehicleParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePartConditions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePartMaintenanceHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaintenanceFinalPrice = table.Column<float>(type: "real", nullable: false),
                    MaintenanceServiceFinalPrice = table.Column<float>(type: "real", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    VehiclePartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePartMaintenanceHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePartMaintenanceHistories_VehicleParts_VehiclePartId",
                        column: x => x.VehiclePartId,
                        principalTable: "VehicleParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePartMaintenanceHistories_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("ab21666f-501c-4fa1-9cdb-1e28a1b11538"), new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9280), "customer@vemo.com", "customer", "y8p7CnUadBvgyIZc3O4CriLVWxdSrPH4s3vYZu7XMF7K+J9n", "customer", null },
                    { new Guid("b7390ca0-27b4-48b9-91ac-25f0216d4365"), new DateTime(2023, 12, 14, 6, 17, 13, 607, DateTimeKind.Utc).AddTicks(5249), "admin@vemo.com", "admin", "GTqUiGEV27X1HrpJ5aCIUmp5I35pbskPBTB3P0f2vgd+ViSr", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "VehicleParts",
                columns: new[] { "Id", "AgeInMonth", "CreatedAt", "MaintenancePrice", "MaintenanceServicePrice", "Name", "UpdatedAt", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("36b8d8bf-d29d-4b0b-b01c-669b2998f1c4"), 8, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9541), 60000f, 20000f, "V-Belt", null, "matic" },
                    { new Guid("3877491e-bfbb-4fa2-972b-316a05ef138e"), 6, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9530), 25000f, 5000f, "Busi", null, null },
                    { new Guid("6818748e-8a6f-4608-b837-9c125ff7f5bb"), 24, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9536), 300000f, 25000f, "Ban", null, null },
                    { new Guid("a013a650-656e-4a63-b9fe-18f98af709b4"), 10, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9528), 30000f, 20000f, "Radiator", null, null },
                    { new Guid("a28c75de-0d0b-43a5-96ec-1d7fb0006733"), 8, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9547), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("ac250928-641a-4e14-acc3-07e678e45a4f"), 9, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9549), 100000f, 20000f, "Kampas Kopling", null, "manual" },
                    { new Guid("c8038437-b554-4cd2-9b36-13502d97d20a"), 5, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9532), 40000f, 15000f, "Rem", null, null },
                    { new Guid("dd4cd404-ea0c-4cf0-9688-83032c4925da"), 3, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9539), 20000f, 10000f, "Aki", null, null },
                    { new Guid("f0f8e9d4-2e24-43ca-bf8c-f859f6d2f554"), 12, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9543), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("f857afd0-01e8-4492-9435-d9d3c3cd7459"), 4, new DateTime(2023, 12, 14, 6, 17, 13, 610, DateTimeKind.Utc).AddTicks(9526), 50000f, 10000f, "Oli", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthInfos_UserId",
                table: "UserAuthInfos",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartConditions_VehicleId",
                table: "VehiclePartConditions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartConditions_VehiclePartId",
                table: "VehiclePartConditions",
                column: "VehiclePartId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartMaintenanceHistories_VehicleId",
                table: "VehiclePartMaintenanceHistories",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartMaintenanceHistories_VehiclePartId",
                table: "VehiclePartMaintenanceHistories",
                column: "VehiclePartId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_LicensePlate",
                table: "Vehicles",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "UserAuthInfos");

            migrationBuilder.DropTable(
                name: "VehiclePartConditions");

            migrationBuilder.DropTable(
                name: "VehiclePartMaintenanceHistories");

            migrationBuilder.DropTable(
                name: "VehicleParts");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
