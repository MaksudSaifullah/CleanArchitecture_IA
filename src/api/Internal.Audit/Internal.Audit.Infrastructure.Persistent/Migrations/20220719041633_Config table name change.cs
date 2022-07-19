using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Configtablenamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Document_DocumentSourceId",
                schema: "Common",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                schema: "config",
                table: "Document");

            migrationBuilder.RenameTable(
                name: "Document",
                schema: "config",
                newName: "DocumentSource",
                newSchema: "config");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentSource",
                schema: "config",
                table: "DocumentSource",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentSource_DocumentSourceId",
                schema: "Common",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentSource",
                schema: "config",
                table: "DocumentSource");

            migrationBuilder.RenameTable(
                name: "DocumentSource",
                schema: "config",
                newName: "Document",
                newSchema: "config");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                schema: "config",
                table: "Document",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Document_DocumentSourceId",
                schema: "Common",
                table: "Document",
                column: "DocumentSourceId",
                principalSchema: "config",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
