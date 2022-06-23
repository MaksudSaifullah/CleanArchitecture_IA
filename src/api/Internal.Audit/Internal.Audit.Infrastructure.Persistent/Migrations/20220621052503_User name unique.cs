using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Usernameunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "Security",
                table: "User",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_UserName",
                schema: "Security",
                table: "User");
        }
    }
}
