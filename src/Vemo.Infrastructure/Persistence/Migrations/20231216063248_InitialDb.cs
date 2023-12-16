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
                    { new Guid("0de60c35-d190-48ca-bddd-e8c7e50aee97"), 12, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4106), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("393097ba-8737-40fe-862a-d842a7e99962"), 10, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4062), 30000f, 20000f, "Radiator", null, null },
                    { new Guid("5107e048-f2a9-4cee-8082-bbb386ceb076"), 5, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4083), 40000f, 15000f, "Rem", null, null },
                    { new Guid("6aeefee1-fb66-48a2-b2e0-88089ecab98e"), 4, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4058), 50000f, 10000f, "Oli", null, null },
                    { new Guid("706ab5aa-ff07-4311-854d-5e73ad2c8371"), 8, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4108), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("73b82984-c5f0-4bb3-a404-13cb1383c6bc"), 6, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4081), 25000f, 5000f, "Busi", null, null },
                    { new Guid("a3e3e2a6-f954-4ac9-9461-b49a0feceb1f"), 9, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4110), 100000f, 20000f, "Kampas Kopling", null, "manual" },
                    { new Guid("b9ff0e80-aa1f-43aa-a4e2-3d6022e57bde"), 8, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4103), 60000f, 20000f, "V-Belt", null, "matic" },
                    { new Guid("e272f915-f101-46fd-9c5e-32b5dd39758e"), 24, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4092), 300000f, 25000f, "Ban", null, null },
                    { new Guid("f6b6b79b-5452-4a46-9349-75e33bf1e837"), 3, new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(4095), 20000f, 10000f, "Aki", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("53c96d08-6e9d-4350-b3e9-21e1008b89c5"), new DateTime(2023, 12, 16, 6, 32, 47, 940, DateTimeKind.Utc).AddTicks(3390), "customer@vemo.com", "customer", "TUcAZcC1KOwJaVgCWFsc4AXJVcMEHCaoBbWcTYPd2SAZgB8n", "customer", null },
                    { new Guid("7575941d-9ba1-4588-89fb-72a430eabab2"), new DateTime(2023, 12, 16, 6, 32, 47, 934, DateTimeKind.Utc).AddTicks(2922), "admin@vemo.com", "admin", "BKqGre1UnWBqEZqMDmmIU5b83HTCrR2hfXR2avoAcZH8w0NB", "admin", null }
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
