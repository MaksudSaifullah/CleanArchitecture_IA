using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class issuevalidationfkidfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationEvidenceDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationEvidenceDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                column: "IssueValidationId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                column: "IssueValidationId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationEvidenceDetail_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationEvidenceDetail_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail");

            migrationBuilder.DropColumn(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationEvidenceDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                column: "IssueValidationActionPlanId");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                column: "IssueValidationActionPlanId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id");
        }
    }
}
