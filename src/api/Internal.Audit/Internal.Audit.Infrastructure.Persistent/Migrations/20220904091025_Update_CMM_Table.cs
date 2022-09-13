using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Update_CMM_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AgreedByUserId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PreparedByUserId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgreedByUserId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes");

            migrationBuilder.DropColumn(
                name: "PreparedByUserId",
                schema: "BranchAudit",
                table: "ClosingMeetingMinutes");
        }
    }
}
