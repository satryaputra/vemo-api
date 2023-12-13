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

            migrationBuilder.CreateTable(
                name: "VehiclePartMaintenanceSchedules",
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
                    table.PrimaryKey("PK_VehiclePartMaintenanceSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePartMaintenanceSchedules_VehicleParts_VehiclePartId",
                        column: x => x.VehiclePartId,
                        principalTable: "VehicleParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePartMaintenanceSchedules_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VehicleParts",
                columns: new[] { "Id", "AgeInMonth", "CreatedAt", "MaintenancePrice", "MaintenanceServicePrice", "Name", "UpdatedAt", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("2bcfae8e-0aba-4ce6-823a-4117b94ace55"), 6, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7593), 25000f, 5000f, "Busi", null, null },
                    { new Guid("84a6070f-70b5-41b5-aacc-53b3f4d5732c"), 9, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7616), 100000f, 20000f, "Kampas Kopling", null, "manual" },
                    { new Guid("8b004f17-b152-40f1-90c9-760ce584ff63"), 4, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7589), 50000f, 10000f, "Oli", null, null },
                    { new Guid("a49e2cd4-fbc8-4a04-8fd8-759627870e15"), 3, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7608), 20000f, 10000f, "Aki", null, null },
                    { new Guid("b663225a-e936-455a-8bb9-c185e1a56bab"), 24, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7606), 300000f, 25000f, "Ban", null, null },
                    { new Guid("ba078600-1309-413d-bdac-1c9d01e01523"), 5, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7605), 40000f, 15000f, "Rem", null, null },
                    { new Guid("be8addb4-d0bf-4d45-810a-19e9c9b77182"), 12, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7613), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("d616d6ab-37b9-4b39-a5dc-438183cd34b1"), 8, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7609), 60000f, 20000f, "V-Belt", null, "matic" },
                    { new Guid("ebf3b9b9-aee0-4ea6-bac2-a0b19a5b0651"), 8, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7615), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("ffb0e187-1942-4d21-8e3e-2e5e6ae948f4"), 10, new DateTime(2023, 12, 13, 9, 18, 9, 285, DateTimeKind.Utc).AddTicks(7591), 30000f, 20000f, "Radiator", null, null }
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
                name: "IX_VehiclePartMaintenanceHistories_VehicleId",
                table: "VehiclePartMaintenanceHistories",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartMaintenanceHistories_VehiclePartId",
                table: "VehiclePartMaintenanceHistories",
                column: "VehiclePartId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartMaintenanceSchedules_VehicleId",
                table: "VehiclePartMaintenanceSchedules",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePartMaintenanceSchedules_VehiclePartId",
                table: "VehiclePartMaintenanceSchedules",
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
                name: "VehiclePartMaintenanceHistories");

            migrationBuilder.DropTable(
                name: "VehiclePartMaintenanceSchedules");

            migrationBuilder.DropTable(
                name: "VehicleParts");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
