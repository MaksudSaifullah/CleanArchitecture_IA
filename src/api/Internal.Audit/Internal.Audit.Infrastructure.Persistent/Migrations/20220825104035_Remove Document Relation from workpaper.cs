using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RemoveDocumentRelationfromworkpaper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPaper_Document_DocumentId",
                schema: "BranchAudit",
                table: "WorkPaper");

            migrationBuilder.DropIndex(
                name: "IX_WorkPaper_DocumentId",
                schema: "BranchAudit",
                table: "WorkPaper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkPaper_DocumentId",
                schema: "BranchAudit",
                table: "WorkPaper",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPaper_Document_DocumentId",
                schema: "BranchAudit",
                table: "WorkPaper",
                column: "DocumentId",
                principalSchema: "Common",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
