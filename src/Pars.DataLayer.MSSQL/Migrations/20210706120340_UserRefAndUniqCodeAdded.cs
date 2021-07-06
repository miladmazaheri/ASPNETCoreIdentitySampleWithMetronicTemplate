using Microsoft.EntityFrameworkCore.Migrations;

namespace Pars.DataLayer.MSSQL.Migrations
{
    public partial class UserRefAndUniqCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferralCode",
                table: "AppUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueCode",
                table: "AppUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                computedColumnSql: "RIGHT('000000'+CAST([Id] AS VARCHAR(20)),6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferralCode",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "UniqueCode",
                table: "AppUsers");
        }
    }
}
