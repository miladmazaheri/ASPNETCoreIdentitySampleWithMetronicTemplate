using Microsoft.EntityFrameworkCore.Migrations;

namespace Pars.DataLayer.MSSQL.Migrations
{
    public partial class UserApiKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "AppUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "AppUsers");
        }
    }
}
