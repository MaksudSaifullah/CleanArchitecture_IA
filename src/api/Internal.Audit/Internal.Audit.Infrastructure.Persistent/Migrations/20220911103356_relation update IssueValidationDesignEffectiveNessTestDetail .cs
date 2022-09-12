using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class relationupdateIssueValidationDesignEffectiveNessTestDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidation_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.DropColumn(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationActionPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidation_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationActionPlanId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id");
        }
    }
}
