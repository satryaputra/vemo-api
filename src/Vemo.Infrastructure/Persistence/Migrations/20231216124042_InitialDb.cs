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
                    { new Guid("1cfbba50-68c2-48d8-935c-e75c7459b9b8"), 5, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7589), 40000f, 15000f, "Rem", null, null },
                    { new Guid("1e335e39-3dd1-4210-8a77-f119cb26feb0"), 8, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7596), 60000f, 20000f, "V-Belt", null, "matic" },
                    { new Guid("6b64bd30-e011-4a3d-9375-c2dafd112746"), 4, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7579), 50000f, 10000f, "Oli", null, null },
                    { new Guid("717786c0-7673-486b-9d39-cb7a41d4033c"), 8, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7600), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("8f8d9d55-3011-4dc4-b819-873e82f7f751"), 9, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7601), 100000f, 20000f, "Kampas Kopling", null, "manual" },
                    { new Guid("9025bed6-60ce-4ba0-b440-754bc9b130ef"), 24, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7591), 300000f, 25000f, "Ban", null, null },
                    { new Guid("b4522f19-1ea2-4dea-bfaa-6ab708f2ffc7"), 12, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7598), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("ce84e32e-b732-4235-a74f-dc7a08d9db57"), 10, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7582), 30000f, 20000f, "Radiator", null, null },
                    { new Guid("da8198bd-b5d0-451b-a8cb-77bc14d6db22"), 6, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7587), 25000f, 5000f, "Busi", null, null },
                    { new Guid("eeaaad84-03b2-4db6-bb08-65feddfa2ca7"), 3, new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7593), 20000f, 10000f, "Aki", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "Photo", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8d478e2c-e27b-4c71-b0de-8779d92c2e62"), new DateTime(2023, 12, 16, 12, 40, 42, 470, DateTimeKind.Utc).AddTicks(5273), "admin@vemo.com", "admin", "czOPTC7GUjb2N+GHVpwBHfuCuLIseT1PKjuiOE44iJmdl+lv", null, "admin", null },
                    { new Guid("a306652d-6dba-4e74-bac4-2515ff7864d4"), new DateTime(2023, 12, 16, 12, 40, 42, 473, DateTimeKind.Utc).AddTicks(7474), "customer@vemo.com", "customer", "LHWkaVWNzPZS8piwSlznbnn39+rZa076AUCb422fPW/gyt47", null, "customer", null }
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
