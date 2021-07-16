using Microsoft.EntityFrameworkCore.Migrations;

namespace Pars.DataLayer.MSSQL.Migrations
{
    public partial class UserRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var q = @"BEGIN
   IF NOT EXISTS (SELECT * FROM AppRoles WHERE NormalizedName = N'USER')
   BEGIN
       INSERT INTO [dbo].[AppRoles]([Name],[NormalizedName]) VALUES (N'User',N'USER')
   END
END";
            migrationBuilder.Sql(q);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
