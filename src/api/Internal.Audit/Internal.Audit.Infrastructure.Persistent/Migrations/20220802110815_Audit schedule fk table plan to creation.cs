using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Auditschedulefktableplantocreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditSchedule_AuditPlan_AuditPlanId",
                schema: "BranchAudit",
                table: "AuditSchedule");

            migrationBuilder.RenameColumn(
                name: "AuditPlanId",
                schema: "BranchAudit",
                table: "AuditSchedule",
                newName: "AuditCreationId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditSchedule_AuditPlanId",
                schema: "BranchAudit",
                table: "AuditSchedule",
                newName: "IX_AuditSchedule_AuditCreationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditSchedule_AuditCreation_AuditCreationId",
                schema: "BranchAudit",
                table: "AuditSchedule",
                column: "AuditCreationId",
                principalSchema: "BranchAudit",
                principalTable: "AuditCreation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditSchedule_AuditCreation_AuditCreationId",
                schema: "BranchAudit",
                table: "AuditSchedule");

            migrationBuilder.RenameColumn(
                name: "AuditCreationId",
                schema: "BranchAudit",
                table: "AuditSchedule",
                newName: "AuditPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_AuditSchedule_AuditCreationId",
                schema: "BranchAudit",
                table: "AuditSchedule",
                newName: "IX_AuditSchedule_AuditPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditSchedule_AuditPlan_AuditPlanId",
                schema: "BranchAudit",
                table: "AuditSchedule",
                column: "AuditPlanId",
                principalSchema: "BranchAudit",
                principalTable: "AuditPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
