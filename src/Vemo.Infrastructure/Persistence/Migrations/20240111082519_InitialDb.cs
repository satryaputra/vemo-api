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
                name: "Parts",
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
                    table.PrimaryKey("PK_Parts", x => x.Id);
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
                    Photo = table.Column<string>(type: "text", nullable: true),
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
                    MaintenanceStatus = table.Column<string>(type: "text", nullable: true),
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
                name: "ConditionParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastMaintenance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PartId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConditionParts_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceVehicles",
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
                    table.PrimaryKey("PK_MaintenanceVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceParts",
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
                    table.PrimaryKey("PK_MaintenanceParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceParts_MaintenanceVehicles_MaintenanceVehicleId",
                        column: x => x.MaintenanceVehicleId,
                        principalTable: "MaintenanceVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceParts_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "AgeInMonth", "CreatedAt", "MaintenancePrice", "MaintenanceServicePrice", "Name", "UpdatedAt", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("2b1b9460-de49-432a-a138-e72ff47ceda9"), 8, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7915), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("3de6619e-0863-42cd-a920-820fd20fc1ba"), 24, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7898), 300000f, 25000f, "Ban", null, null },
                    { new Guid("4849f242-ac10-4985-8aca-e7e3bf3a8033"), 4, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7868), 50000f, 10000f, "Oli", null, null },
                    { new Guid("55b4f572-cc8f-4f2a-a508-a662df04555d"), 6, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7887), 25000f, 5000f, "Busi", null, null },
                    { new Guid("5af90db0-fb10-494a-acfd-12e6a7d8f7a4"), 12, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7912), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("63533620-f26f-4d49-b8d1-587fcc298290"), 3, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7906), 20000f, 10000f, "Aki", null, null },
                    { new Guid("9325fd9f-8232-4c5e-9bfb-b4db96b009c3"), 10, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7884), 30000f, 20000f, "Radiator", null, null },
                    { new Guid("a61840b5-fbad-4081-805a-badaa8e54f4a"), 9, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7921), 100000f, 20000f, "Kampas Kopling", null, "manual" },
                    { new Guid("e7d16d78-c120-4023-b86d-f9473f598ab4"), 8, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7909), 60000f, 20000f, "V-Belt", null, "matic" },
                    { new Guid("ed362008-5f8e-48fe-aee8-03ed65b39b18"), 5, new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7890), 40000f, 15000f, "Rem", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Photo", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3fe05da8-2812-47cf-b530-a0acd9f701e4"), new DateTime(2024, 1, 11, 8, 25, 19, 222, DateTimeKind.Utc).AddTicks(7806), "admin@vemo.com", "admin", "BlTosvmRb2mqvtWxKCFKSmNo/Zqr9RZc9z7PIbDO17rwnWbg", null, "admin", null },
                    { new Guid("7e0e1819-9f03-4b3b-9e01-2e33bb763adc"), new DateTime(2024, 1, 11, 8, 25, 19, 226, DateTimeKind.Utc).AddTicks(7288), "customer@vemo.com", "customer", "df42AH/l7MHQatP3zh7iL6SHUjpgbkTz4rLxy8MRCIwva8xv", null, "customer", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthInfos_UserId",
                table: "AuthInfos",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConditionParts_PartId",
                table: "ConditionParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionParts_VehicleId",
                table: "ConditionParts",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceParts_MaintenanceVehicleId",
                table: "MaintenanceParts",
                column: "MaintenanceVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceParts_PartId",
                table: "MaintenanceParts",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceVehicles_VehicleId",
                table: "MaintenanceVehicles",
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
                name: "ConditionParts");

            migrationBuilder.DropTable(
                name: "MaintenanceParts");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "MaintenanceVehicles");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
