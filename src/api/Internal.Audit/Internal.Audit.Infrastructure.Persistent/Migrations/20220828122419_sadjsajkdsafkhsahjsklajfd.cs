using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class sadjsajkdsafkhsahjsklajfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditScheduleBranch_Issue_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleBranch");

            migrationBuilder.DropForeignKey(
                name: "FK_AuditScheduleParticipants_Issue_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleParticipants");

            migrationBuilder.DropTable(
                name: "IssueOwner",
                schema: "Config");

            migrationBuilder.DropIndex(
                name: "IX_AuditScheduleParticipants_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleParticipants");

            migrationBuilder.DropIndex(
                name: "IX_AuditScheduleBranch_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleBranch");

            migrationBuilder.DropColumn(
                name: "IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleParticipants");

            migrationBuilder.DropColumn(
                name: "IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleBranch");

            migrationBuilder.AlterColumn<string>(
                name: "IssueTitle",
                schema: "BranchAudit",
                table: "Issue",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "BranchAudit",
                table: "Issue",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "0");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "BranchAudit",
                table: "Issue",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_AuditScheduleId",
                schema: "BranchAudit",
                table: "Issue",
                column: "AuditScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_AuditSchedule_AuditScheduleId",
                schema: "BranchAudit",
                table: "Issue",
                column: "AuditScheduleId",
                principalSchema: "BranchAudit",
                principalTable: "AuditSchedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_AuditSchedule_AuditScheduleId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_AuditScheduleId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.AlterColumn<string>(
                name: "IssueTitle",
                schema: "BranchAudit",
                table: "Issue",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "BranchAudit",
                table: "Issue",
                type: "bit",
                nullable: false,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "BranchAudit",
                table: "Issue",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleParticipants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleBranch",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IssueOwner",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueOwner_Employee_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Security",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueOwner_Issue_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "BranchAudit",
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditScheduleParticipants_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleParticipants",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditScheduleBranch_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleBranch",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOwner_IssueId",
                schema: "Config",
                table: "IssueOwner",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOwner_OwnerId",
                schema: "Config",
                table: "IssueOwner",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditScheduleBranch_Issue_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleBranch",
                column: "IssueId",
                principalSchema: "BranchAudit",
                principalTable: "Issue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditScheduleParticipants_Issue_IssueId",
                schema: "BranchAudit",
                table: "AuditScheduleParticipants",
                column: "IssueId",
                principalSchema: "BranchAudit",
                principalTable: "Issue",
                principalColumn: "Id");
        }
    }
}
