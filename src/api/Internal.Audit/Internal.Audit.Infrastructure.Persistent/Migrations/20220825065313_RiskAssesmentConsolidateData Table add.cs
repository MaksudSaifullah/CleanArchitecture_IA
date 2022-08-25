using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RiskAssesmentConsolidateDataTableadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskAssesmentConsolidateData",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    RiskAssesmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    Loproductivity_Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Loproductivity_Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fraud_Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fraud_Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffTurnOver_Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffTurnOver_Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverDue_Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverDue_Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Collection_Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Collection_Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disbursement_Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disbursement_Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_RiskAssesmentConsolidateData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskAssesmentConsolidateData",
                schema: "BranchAudit");
        }
    }
}
