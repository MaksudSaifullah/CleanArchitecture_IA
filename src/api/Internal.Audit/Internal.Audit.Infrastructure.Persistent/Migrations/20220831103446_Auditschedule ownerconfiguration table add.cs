using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Auditscheduleownerconfigurationtableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditScheduleConfigurationOwner",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    AuditScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommonValueAuditScheduleRiskOwnerTypetId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditScheduleConfigurationOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditScheduleConfigurationOwner_AuditSchedule_AuditScheduleId",
                        column: x => x.AuditScheduleId,
                        principalSchema: "BranchAudit",
                        principalTable: "AuditSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditScheduleConfigurationOwner_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditScheduleConfigurationOwner_AuditScheduleId",
                schema: "BranchAudit",
                table: "AuditScheduleConfigurationOwner",
                column: "AuditScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditScheduleConfigurationOwner_UserId",
                schema: "BranchAudit",
                table: "AuditScheduleConfigurationOwner",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditScheduleConfigurationOwner",
                schema: "BranchAudit");
        }
    }
}
