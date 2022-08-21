using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class DMlogRiskassesmentidadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RiskAssessmentId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagementLog",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssesmentDataManagementLog_RiskAssessmentId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagementLog",
                column: "RiskAssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskAssesmentDataManagementLog_RiskAssessment_RiskAssessmentId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagementLog",
                column: "RiskAssessmentId",
                principalSchema: "BranchAudit",
                principalTable: "RiskAssessment",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskAssesmentDataManagementLog_RiskAssessment_RiskAssessmentId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagementLog");

            migrationBuilder.DropIndex(
                name: "IX_RiskAssesmentDataManagementLog_RiskAssessmentId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagementLog");

            migrationBuilder.DropColumn(
                name: "RiskAssessmentId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagementLog");
        }
    }
}
