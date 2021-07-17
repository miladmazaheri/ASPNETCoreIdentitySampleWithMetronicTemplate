using Microsoft.EntityFrameworkCore.Migrations;

namespace Pars.DataLayer.MSSQL.Migrations
{
    public partial class OrderIsConfirmedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Orders",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Orders");
        }
    }
}
