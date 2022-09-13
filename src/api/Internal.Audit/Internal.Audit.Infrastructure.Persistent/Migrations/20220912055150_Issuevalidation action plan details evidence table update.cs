using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Issuevalidationactionplandetailsevidencetableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationEvidenceDetail_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationEvidenceDetail_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.DropColumn(
                name: "IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationEvidenceDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                column: "IssueValidationActionPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationEvidenceDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                column: "IssueValidationActionPlanId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationEvidenceDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationEvidenceDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationEvidenceDetail_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                column: "IssueValidationId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationEvidenceDetail_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                column: "IssueValidationId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
