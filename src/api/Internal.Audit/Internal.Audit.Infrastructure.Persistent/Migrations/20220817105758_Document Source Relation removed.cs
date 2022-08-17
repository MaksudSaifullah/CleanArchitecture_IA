using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class DocumentSourceRelationremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentSource_DocumentSourceId",
                schema: "Common",
                table: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Document_DocumentSourceId",
                schema: "Common",
                table: "Document");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentSourceId",
                schema: "Common",
                table: "Document",
                column: "DocumentSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentSource_DocumentSourceId",
                schema: "Common",
                table: "Document",
                column: "DocumentSourceId",
                principalSchema: "config",
                principalTable: "DocumentSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
