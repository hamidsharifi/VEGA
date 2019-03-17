using Microsoft.EntityFrameworkCore.Migrations;

namespace VEGA.Migrations
{
    public partial class VehicleFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleFeature",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeature", x => new { x.VehicleId, x.FeatureId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleFeature");
        }
    }
}
