using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class AuditPlanCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssesmentCode",
                schema: "BranchAudit",
                table: "AuditPlan",
                newName: "PlanCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanCode",
                schema: "BranchAudit",
                table: "AuditPlan",
                newName: "AssesmentCode");
        }
    }
}
