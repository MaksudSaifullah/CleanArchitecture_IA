using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Issuevalitiontableanddependenttableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueValidationActionPlan",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DEATestConclusion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingEffectivenessTestDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleSize = table.Column<int>(type: "int", nullable: false),
                    ControlActivityValue = table.Column<int>(type: "int", nullable: false),
                    ControlFrequencyValue = table.Column<int>(type: "int", nullable: false),
                    OETestConclusion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionValidatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionReviewedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionApprovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionValidationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActionApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewEvidenceDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovalEvidenceDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_IssueValidationActionPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueValidationDesignEffectiveNessTestDetail",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IssueValidationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommonQuestionValue = table.Column<int>(type: "int", nullable: false),
                    CommonAnsValue = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueValidationActionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_IssueValidationDesignEffectiveNessTestDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidation_IssueValidationId",
                        column: x => x.IssueValidationId,
                        principalSchema: "BranchAudit",
                        principalTable: "IssueValidation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                        column: x => x.IssueValidationActionPlanId,
                        principalSchema: "BranchAudit",
                        principalTable: "IssueValidationActionPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueValidationEvidenceDetail",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IssueValidationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueValidationActionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_IssueValidationEvidenceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueValidationEvidenceDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                        column: x => x.IssueValidationActionPlanId,
                        principalSchema: "BranchAudit",
                        principalTable: "IssueValidationActionPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueValidationTestSheet",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IssueValidationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueValidationActionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_IssueValidationTestSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationActionPlanId",
                        column: x => x.IssueValidationActionPlanId,
                        principalSchema: "BranchAudit",
                        principalTable: "IssueValidationActionPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationActionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationEvidenceDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                column: "IssueValidationActionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                column: "IssueValidationActionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueValidationDesignEffectiveNessTestDetail",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "IssueValidationEvidenceDetail",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "IssueValidationTestSheet",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "IssueValidationActionPlan",
                schema: "BranchAudit");
        }
    }
}
