using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Addissuevalidationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueValidation",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewedByUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewEvidenceDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovalEvidenceDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClosureSummary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ValidationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IssueClosureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_IssueValidation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueValidation_Issue_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "BranchAudit",
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueValidation_User_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IssueValidation_User_ReviewedByUserID",
                        column: x => x.ReviewedByUserID,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IssueValidation_User_ValidatedByUserId",
                        column: x => x.ValidatedByUserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidation_ApprovedByUserId",
                schema: "BranchAudit",
                table: "IssueValidation",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidation_IssueId",
                schema: "BranchAudit",
                table: "IssueValidation",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidation_ReviewedByUserID",
                schema: "BranchAudit",
                table: "IssueValidation",
                column: "ReviewedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidation_ValidatedByUserId",
                schema: "BranchAudit",
                table: "IssueValidation",
                column: "ValidatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueValidation",
                schema: "BranchAudit");
        }
    }
}
