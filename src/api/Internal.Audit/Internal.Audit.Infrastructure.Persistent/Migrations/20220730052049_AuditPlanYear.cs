using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class AuditPlanYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanningYear",
                schema: "BranchAudit",
                table: "AuditPlan");

            migrationBuilder.AddColumn<Guid>(
                name: "PlanningYearId",
                schema: "BranchAudit",
                table: "AuditPlan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanningYearId",
                schema: "BranchAudit",
                table: "AuditPlan");

            migrationBuilder.AddColumn<string>(
                name: "PlanningYear",
                schema: "BranchAudit",
                table: "AuditPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
