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
                name: "PartVehicles",
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
                    table.PrimaryKey("PK_PartVehicles", x => x.Id);
                });

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
                name: "AuthInfos",
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
                    table.PrimaryKey("PK_AuthInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ConditionPartVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionPartVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionPartVehicles_PartVehicles_PartId",
                        column: x => x.PartId,
                        principalTable: "PartVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConditionPartVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceVehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePartVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MaintenanceFinalPrice = table.Column<double>(type: "double precision", nullable: false),
                    MaintenanceServiceFinalPrice = table.Column<double>(type: "double precision", nullable: false),
                    MaintenanceVehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePartVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenancePartVehicles_MaintenanceVehicle_MaintenanceVehic~",
                        column: x => x.MaintenanceVehicleId,
                        principalTable: "MaintenanceVehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenancePartVehicles_PartVehicles_PartId",
                        column: x => x.PartId,
                        principalTable: "PartVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PartVehicles",
                columns: new[] { "Id", "AgeInMonth", "CreatedAt", "MaintenancePrice", "MaintenanceServicePrice", "Name", "UpdatedAt", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("072b4168-ac97-4ba1-9d04-94738ef2f0ca"), 24, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9922), 300000f, 25000f, "Ban", null, null },
                    { new Guid("0ab772bc-f543-44d3-8b0e-018bc0e79a08"), 10, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9916), 30000f, 20000f, "Radiator", null, null },
                    { new Guid("0d8a75de-3bee-4344-bbf5-48cc30362de7"), 5, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9920), 40000f, 15000f, "Rem", null, null },
                    { new Guid("0e389c2c-e026-4179-901b-c8da47bbfb7b"), 9, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9934), 100000f, 20000f, "Kampas Kopling", null, "manual" },
                    { new Guid("1966a564-39cf-49e2-b09c-45e45208cd72"), 3, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9925), 20000f, 10000f, "Aki", null, null },
                    { new Guid("1dcc0e7c-aa60-44f7-9f70-0d102a9a887e"), 8, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9927), 60000f, 20000f, "V-Belt", null, "matic" },
                    { new Guid("326f70a3-cd3a-485c-8673-c35ebc81e0b5"), 4, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9909), 50000f, 10000f, "Oli", null, null },
                    { new Guid("5084a8d2-c1c3-4c82-94f1-0796b114ba7d"), 8, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9931), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("5762e3be-0581-4a71-85a6-41b412fe8a11"), 12, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9929), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("dafdf6f4-a1bd-414b-b2e0-03433afbe4ca"), 6, new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9918), 25000f, 5000f, "Busi", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7e7eecb5-e92b-48bc-a5d2-f518e6b9462f"), new DateTime(2023, 12, 14, 13, 56, 58, 631, DateTimeKind.Utc).AddTicks(8183), "admin@vemo.com", "admin", "+JHxeivwJk30Tz6siVjKhh9zQjr6/NRFuxvcvHbwVuv2wiWo", "admin", null },
                    { new Guid("c94dd6b2-8269-4cf2-a39f-7aa11eee2996"), new DateTime(2023, 12, 14, 13, 56, 58, 634, DateTimeKind.Utc).AddTicks(9756), "customer@vemo.com", "customer", "KHMMQF5ydL4D6ZZG+HcQ/eaEBTo9MOUQvWc+tzfqj4aNVefZ", "customer", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthInfos_UserId",
                table: "AuthInfos",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConditionPartVehicles_PartId",
                table: "ConditionPartVehicles",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionPartVehicles_VehicleId",
                table: "ConditionPartVehicles",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePartVehicles_MaintenanceVehicleId",
                table: "MaintenancePartVehicles",
                column: "MaintenanceVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePartVehicles_PartId",
                table: "MaintenancePartVehicles",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVehicle_VehicleId",
                table: "MaintenanceVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

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
                name: "AuthInfos");

            migrationBuilder.DropTable(
                name: "ConditionPartVehicles");

            migrationBuilder.DropTable(
                name: "MaintenancePartVehicles");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "MaintenanceVehicle");

            migrationBuilder.DropTable(
                name: "PartVehicles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
