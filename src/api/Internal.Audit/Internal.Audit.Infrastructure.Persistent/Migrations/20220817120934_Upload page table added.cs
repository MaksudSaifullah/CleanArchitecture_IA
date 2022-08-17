using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Uploadpagetableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UploadDocument",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    DocumentVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UploadedDocumentsNotify",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMailSent = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    UploadDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedDocumentsNotify", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadedDocumentsNotify_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UploadedDocumentsNotify_UploadDocument_UploadDocumentId",
                        column: x => x.UploadDocumentId,
                        principalSchema: "Config",
                        principalTable: "UploadDocument",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedDocumentsNotify_RoleId",
                schema: "Config",
                table: "UploadedDocumentsNotify",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedDocumentsNotify_UploadDocumentId",
                schema: "Config",
                table: "UploadedDocumentsNotify",
                column: "UploadDocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadedDocumentsNotify",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "UploadDocument",
                schema: "Config");
        }
    }
}
