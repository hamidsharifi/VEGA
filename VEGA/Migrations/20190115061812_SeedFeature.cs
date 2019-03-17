using Microsoft.EntityFrameworkCore.Migrations;

namespace VEGA.Migrations
{
    public partial class SeedFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature01')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature02')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature03')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature04')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature05')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Features WHERE Name IN ('Feature01', 'Feature02', 'Feature03', 'Feature04', 'Feature05')");
        }
    }
}
