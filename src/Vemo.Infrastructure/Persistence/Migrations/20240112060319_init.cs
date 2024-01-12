using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vemo.Infrastructure.Persistence.Migrations
{
    public partial class init : Migration
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
                    Ticket = table.Column<string>(type: "text", nullable: false),
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
                    { new Guid("2fee4c1b-f36a-4855-93b6-2c41cf216087"), 8, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6744), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("4abbf521-fec6-4b64-908a-a8299a16bae1"), 6, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6704), 25000f, 5000f, "Busi", null, null },
                    { new Guid("529952b5-cb9b-459a-ba2a-d398f5586de1"), 24, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6730), 300000f, 25000f, "Ban", null, null },
                    { new Guid("5653d25a-8fd9-4ed6-826a-b84796194d0e"), 3, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6732), 20000f, 10000f, "Aki", null, null },
                    { new Guid("63a4e801-910b-4789-895d-d39d04eda271"), 4, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6697), 50000f, 10000f, "Oli", null, null },
                    { new Guid("c7fcf570-1bee-4e9d-bd7f-08e45adfdb34"), 10, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6702), 30000f, 20000f, "Radiator", null, null },
                    { new Guid("caa9cb1b-66c5-4377-bb96-a9e563a3643f"), 12, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6741), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("d1d2cb70-b518-4387-93a2-6a8410dc7f5a"), 5, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6727), 40000f, 15000f, "Rem", null, null },
                    { new Guid("d794ad5a-adb6-4198-8948-ba4c4df1359b"), 9, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6747), 100000f, 20000f, "Kampas Kopling", null, "manual" },
                    { new Guid("fa1e807e-d867-4269-98fc-a2c9e1297509"), 8, new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(6735), 60000f, 20000f, "V-Belt", null, "matic" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Photo", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7d405102-ef1f-43ef-b16e-7a6a0ed864f6"), new DateTime(2024, 1, 12, 6, 3, 19, 402, DateTimeKind.Utc).AddTicks(7967), "admin@vemo.com", "admin", "rKzX5cZdFfvShlhwzYeXWd06eMvP2/AyKKDVHNHvQMV9mVnR", null, "admin", null },
                    { new Guid("a90a5c7b-c4fb-4a7b-8692-73b11b24bf23"), new DateTime(2024, 1, 12, 6, 3, 19, 407, DateTimeKind.Utc).AddTicks(5547), "customer@vemo.com", "customer", "eYVctJ0O2oEMQnlbiJD+/PH9bOVXcp4X9YUmSPue/E1+fvOm", null, "customer", null }
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
