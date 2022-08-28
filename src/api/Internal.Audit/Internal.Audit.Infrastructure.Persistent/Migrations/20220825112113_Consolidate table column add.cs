using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Consolidatetablecolumnadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuditFrequency_Type",
                schema: "BranchAudit",
                table: "RiskAssesmentConsolidateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Avg_Rating",
                schema: "BranchAudit",
                table: "RiskAssesmentConsolidateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Avg_Score",
                schema: "BranchAudit",
                table: "RiskAssesmentConsolidateData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditFrequency_Type",
                schema: "BranchAudit",
                table: "RiskAssesmentConsolidateData");

            migrationBuilder.DropColumn(
                name: "Avg_Rating",
                schema: "BranchAudit",
                table: "RiskAssesmentConsolidateData");

            migrationBuilder.DropColumn(
                name: "Avg_Score",
                schema: "BranchAudit",
                table: "RiskAssesmentConsolidateData");
        }
    }
}
