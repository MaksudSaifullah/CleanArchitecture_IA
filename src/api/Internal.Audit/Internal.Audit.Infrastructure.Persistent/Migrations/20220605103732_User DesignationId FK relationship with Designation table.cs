using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class UserDesignationIdFKrelationshipwithDesignationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_DesignationId",
                schema: "Security",
                table: "User",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Designation_DesignationId",
                schema: "Security",
                table: "User",
                column: "DesignationId",
                principalSchema: "Common",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Designation_DesignationId",
                schema: "Security",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DesignationId",
                schema: "Security",
                table: "User");
        }
    }
}
