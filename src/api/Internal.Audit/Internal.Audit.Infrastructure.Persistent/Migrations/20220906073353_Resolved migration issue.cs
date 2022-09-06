using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Resolvedmigrationissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_User_AuditScheduleConfigurationOwner_AuditScheduleConfigurationOwnerId",
            //    schema: "Security",
            //    table: "User");

            //migrationBuilder.DropIndex(
            //    name: "IX_User_AuditScheduleConfigurationOwnerId",
            //    schema: "Security",
            //    table: "User");

            //migrationBuilder.DropColumn(
            //    name: "AuditScheduleConfigurationOwnerId",
            //    schema: "Security",
            //    table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<Guid>(
            //    name: "AuditScheduleConfigurationOwnerId",
            //    schema: "Security",
            //    table: "User",
            //    type: "uniqueidentifier",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_User_AuditScheduleConfigurationOwnerId",
            //    schema: "Security",
            //    table: "User",
            //    column: "AuditScheduleConfigurationOwnerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_User_AuditScheduleConfigurationOwner_AuditScheduleConfigurationOwnerId",
            //    schema: "Security",
            //    table: "User",
            //    column: "AuditScheduleConfigurationOwnerId",
            //    principalSchema: "BranchAudit",
            //    principalTable: "AuditScheduleConfigurationOwner",
            //    principalColumn: "Id");
        }
    }
}
