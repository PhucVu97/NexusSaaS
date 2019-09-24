using Microsoft.EntityFrameworkCore.Migrations;

namespace NexusSaaS.Migrations
{
    public partial class NexusSaaSMigration_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Credentials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Credentials",
                nullable: true);
        }
    }
}
