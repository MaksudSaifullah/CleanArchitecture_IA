using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Change_workpaper_BranchId_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BranchId",
                schema: "BranchAudit",
                table: "WorkPaper",
                newName: "AuditScheduleBranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuditScheduleBranchId",
                schema: "BranchAudit",
                table: "WorkPaper",
                newName: "BranchId");
        }
    }
}
