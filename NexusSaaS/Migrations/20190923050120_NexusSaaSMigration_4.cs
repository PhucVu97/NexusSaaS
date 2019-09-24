using Microsoft.EntityFrameworkCore.Migrations;

namespace NexusSaaS.Migrations
{
    public partial class NexusSaaSMigration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Credentials",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "OwnerId",
                table: "Credentials",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
