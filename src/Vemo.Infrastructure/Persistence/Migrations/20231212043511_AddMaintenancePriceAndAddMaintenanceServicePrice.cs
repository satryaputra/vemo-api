using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vemo.Infrastructure.Persistence.Migrations
{
    public partial class AddMaintenancePriceAndAddMaintenanceServicePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "MaintenancePrice",
                table: "VehicleParts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MaintenanceServicePrice",
                table: "VehicleParts",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenancePrice",
                table: "VehicleParts");

            migrationBuilder.DropColumn(
                name: "MaintenanceServicePrice",
                table: "VehicleParts");
        }
    }
}
