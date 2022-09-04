using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RiskAssesmentDataManagementvaluecolumntypechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagement",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Value",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagement",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");
        }
    }
}
