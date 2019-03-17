using Microsoft.EntityFrameworkCore.Migrations;

namespace VEGA.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes(Name) VALUES('Make3')");

            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelA-Make1', (SELECT Id FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelB-Make1', (SELECT Id FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelC-Make1', (SELECT Id FROM Makes WHERE Name = 'Make1'))");

            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelA-Make2', (SELECT Id FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelB-Make2', (SELECT Id FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelC-Make2', (SELECT Id FROM Makes WHERE Name = 'Make2'))");

            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelA-Make3', (SELECT Id FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelB-Make3', (SELECT Id FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES('ModelC-Make3', (SELECT Id FROM Makes WHERE Name = 'Make3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE Makes WHERE Name IN('Make1', 'Make2', 'Make3')");
        }
    }
}
