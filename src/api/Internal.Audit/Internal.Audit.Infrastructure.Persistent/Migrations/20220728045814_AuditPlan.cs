using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class AuditPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditPlan",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    RiskAssesmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssesmentCode = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PlanningYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssesmentFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssesmentTo = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_AuditPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditPlan_RiskAssesment_RiskAssesmentId",
                        column: x => x.RiskAssesmentId,
                        principalSchema: "BranchAudit",
                        principalTable: "RiskAssesment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditPlan_RiskAssesmentId",
                schema: "BranchAudit",
                table: "AuditPlan",
                column: "RiskAssesmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditPlan",
                schema: "BranchAudit");
        }
    }
}
