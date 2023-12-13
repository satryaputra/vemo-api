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
                table: "VehicleParts",
                columns: new[] { "Id", "AgeInMonth", "CreatedAt", "MaintenancePrice", "MaintenanceServicePrice", "Name", "UpdatedAt", "VehicleType" },
                values: new object[,]
                {
                    { new Guid("054c38e2-a176-42a2-a6ed-b2ebceb0c67f"), 6, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6878), 25000f, 5000f, "Busi", null, null },
                    { new Guid("0bbc6d37-16db-4a84-8e65-3f8a9079b072"), 10, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6875), 30000f, 20000f, "Radiator", null, null },
                    { new Guid("0cc92144-ffff-4ace-baf6-d9d47b54f0ec"), 8, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6891), 100000f, 20000f, "Rantai dan Gear", null, "manual" },
                    { new Guid("39272e95-acde-436c-aa59-bf9c3c947b8a"), 3, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6886), 20000f, 10000f, "Aki", null, null },
                    { new Guid("47647a64-2114-4781-83cf-73b9c56bd725"), 5, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6880), 40000f, 15000f, "Rem", null, null },
                    { new Guid("506b85f3-3fac-47ca-b31a-8be2e3c503e5"), 24, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6881), 300000f, 25000f, "Ban", null, null },
                    { new Guid("91ea877b-f36b-4447-9041-98c8f9d73aa0"), 12, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6889), 100000f, 20000f, "CVT", null, "matic" },
                    { new Guid("93998af9-57f8-43eb-82ce-e31eedee4973"), 8, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6888), 60000f, 20000f, "V-Belt", null, "matic" },
                    { new Guid("c8d2201a-0be9-45a2-a2ab-8596286ad219"), 4, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6861), 50000f, 10000f, "Oli", null, null },
                    { new Guid("d03aa7c6-7e1c-4de7-87a7-af5e53a54ed0"), 9, new DateTime(2023, 12, 13, 14, 5, 18, 401, DateTimeKind.Utc).AddTicks(6895), 100000f, 20000f, "Kampas Kopling", null, "manual" }
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
