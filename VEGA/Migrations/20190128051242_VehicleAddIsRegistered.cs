using Microsoft.EntityFrameworkCore.Migrations;

namespace VEGA.Migrations
{
    public partial class VehicleAddIsRegistered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Vehicles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Vehicles");
        }
    }
}
