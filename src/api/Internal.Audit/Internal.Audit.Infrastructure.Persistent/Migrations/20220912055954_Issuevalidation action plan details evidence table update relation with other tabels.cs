using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Issuevalidationactionplandetailsevidencetableupdaterelationwithothertabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.DropColumn(
                name: "IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropColumn(
                name: "IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                column: "IssueValidationActionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationActionPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationActionPlanId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                column: "IssueValidationActionPlanId",
                principalSchema: "BranchAudit",
                principalTable: "IssueValidationActionPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueValidationTestSheet_IssueValidationActionPlan_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationTestSheet_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet");

            migrationBuilder.DropIndex(
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlanId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationTestSheet",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IssueValidationId",
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
                name: "IX_IssueValidationDesignEffectiveNessTestDetail_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
                column: "IssueValidationId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueValidationDesignEffectiveNessTestDetail_IssueValidationActionPlan_IssueValidationId",
                schema: "BranchAudit",
                table: "IssueValidationDesignEffectiveNessTestDetail",
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
    }
}
