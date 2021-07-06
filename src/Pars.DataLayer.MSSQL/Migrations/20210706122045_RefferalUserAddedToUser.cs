using Microsoft.EntityFrameworkCore.Migrations;

namespace Pars.DataLayer.MSSQL.Migrations
{
    public partial class RefferalUserAddedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferralCode",
                table: "AppUsers");

            migrationBuilder.AddColumn<int>(
                name: "ReferralUserId",
                table: "AppUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueCode",
                table: "AppUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                computedColumnSql: "RIGHT('000000'+CAST([Id] AS VARCHAR(20)),6)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComputedColumnSql: "SELECT RIGHT('000000'+CAST([Id] AS VARCHAR(20)),6)");

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_ReferralUserId",
                table: "AppUsers",
                column: "ReferralUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_AppUsers_ReferralUserId",
                table: "AppUsers",
                column: "ReferralUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_AppUsers_ReferralUserId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_ReferralUserId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ReferralUserId",
                table: "AppUsers");

            migrationBuilder.AddColumn<string>(
                name: "ReferralCode",
                table: "AppUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UniqueCode",
                table: "AppUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                computedColumnSql: "SELECT RIGHT('000000'+CAST([Id] AS VARCHAR(20)),6)",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComputedColumnSql: "RIGHT('000000'+CAST([Id] AS VARCHAR(20)),6)");
        }
    }
}
