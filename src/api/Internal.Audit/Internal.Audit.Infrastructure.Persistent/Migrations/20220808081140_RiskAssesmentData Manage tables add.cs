using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RiskAssesmentDataManagetablesadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskAssesmentDataManagementLog",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    DataRequestQueueServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversionRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RiskAssesmentDataManagementLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskAssesmentDataManagementLog_DataRequestQueueService_DataRequestQueueServiceId",
                        column: x => x.DataRequestQueueServiceId,
                        principalSchema: "Security",
                        principalTable: "DataRequestQueueService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RiskAssesmentDataManagement",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RiskAssesmentDataManagementLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_RiskAssesmentDataManagement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiskAssesmentDataManagement_RiskAssesmentDataManagementLog_RiskAssesmentDataManagementLogId",
                        column: x => x.RiskAssesmentDataManagementLogId,
                        principalSchema: "BranchAudit",
                        principalTable: "RiskAssesmentDataManagementLog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssesmentDataManagement_RiskAssesmentDataManagementLogId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagement",
                column: "RiskAssesmentDataManagementLogId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskAssesmentDataManagementLog_DataRequestQueueServiceId",
                schema: "BranchAudit",
                table: "RiskAssesmentDataManagementLog",
                column: "DataRequestQueueServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiskAssesmentDataManagement",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "RiskAssesmentDataManagementLog",
                schema: "BranchAudit");
        }
    }
}
