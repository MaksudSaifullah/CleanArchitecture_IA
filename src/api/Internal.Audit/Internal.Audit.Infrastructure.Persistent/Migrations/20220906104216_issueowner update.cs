using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class issueownerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueOwner_Employee_OwnerId",
                schema: "Config",
                table: "IssueOwner");

            migrationBuilder.DropIndex(
                name: "IX_IssueOwner_OwnerId",
                schema: "Config",
                table: "IssueOwner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_IssueOwner_OwnerId",
                schema: "Config",
                table: "IssueOwner",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueOwner_Employee_OwnerId",
                schema: "Config",
                table: "IssueOwner",
                column: "OwnerId",
                principalSchema: "Security",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
