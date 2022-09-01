using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Configauditscheduletableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditScheduleConfigurationOwner_User_UserId",
                schema: "BranchAudit",
                table: "AuditScheduleConfigurationOwner");

            migrationBuilder.DropIndex(
                name: "IX_AuditScheduleConfigurationOwner_UserId",
                schema: "BranchAudit",
                table: "AuditScheduleConfigurationOwner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AuditScheduleConfigurationOwner_UserId",
                schema: "BranchAudit",
                table: "AuditScheduleConfigurationOwner",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditScheduleConfigurationOwner_User_UserId",
                schema: "BranchAudit",
                table: "AuditScheduleConfigurationOwner",
                column: "UserId",
                principalSchema: "Security",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
