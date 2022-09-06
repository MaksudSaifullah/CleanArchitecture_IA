using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Update_CMM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreedByUserId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes");

            migrationBuilder.RenameColumn(
                name: "PreparedByUserId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes",
                newName: "AuditScheduleBranchId");

            migrationBuilder.AddColumn<Guid>(
                name: "AuditScheduleConfigurationOwnerId",
                schema: "Security",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AuditScheduleConfigurationOwnerId",
                schema: "Security",
                table: "User",
                column: "AuditScheduleConfigurationOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AuditScheduleConfigurationOwner_AuditScheduleConfigurationOwnerId",
                schema: "Security",
                table: "User",
                column: "AuditScheduleConfigurationOwnerId",
                principalSchema: "BranchAudit",
                principalTable: "AuditScheduleConfigurationOwner",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AuditScheduleConfigurationOwner_AuditScheduleConfigurationOwnerId",
                schema: "Security",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_AuditScheduleConfigurationOwnerId",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AuditScheduleConfigurationOwnerId",
                schema: "Security",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "AuditScheduleBranchId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes",
                newName: "PreparedByUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "AgreedByUserId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
