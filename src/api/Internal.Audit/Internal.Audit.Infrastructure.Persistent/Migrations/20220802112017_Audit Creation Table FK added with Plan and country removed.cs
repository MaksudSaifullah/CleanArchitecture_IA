using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class AuditCreationTableFKaddedwithPlanandcountryremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditCreation_Country_CountryId",
                schema: "BranchAudit",
                table: "AuditCreation");

            migrationBuilder.DropColumn(
                name: "PlanId",
                schema: "BranchAudit",
                table: "AuditCreation");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                schema: "BranchAudit",
                table: "AuditCreation",
                newName: "AuditPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditCreation_CountryId",
                schema: "BranchAudit",
                table: "AuditCreation",
                newName: "IX_AuditCreation_AuditPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditCreation_AuditPlan_AuditPlanId",
                schema: "BranchAudit",
                table: "AuditCreation",
                column: "AuditPlanId",
                principalSchema: "BranchAudit",
                principalTable: "AuditPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditCreation_AuditPlan_AuditPlanId",
                schema: "BranchAudit",
                table: "AuditCreation");

            migrationBuilder.RenameColumn(
                name: "AuditPlanId",
                schema: "BranchAudit",
                table: "AuditCreation",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditCreation_AuditPlanId",
                schema: "BranchAudit",
                table: "AuditCreation",
                newName: "IX_AuditCreation_CountryId");

            migrationBuilder.AddColumn<string>(
                name: "PlanId",
                schema: "BranchAudit",
                table: "AuditCreation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditCreation_Country_CountryId",
                schema: "BranchAudit",
                table: "AuditCreation",
                column: "CountryId",
                principalSchema: "common",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
