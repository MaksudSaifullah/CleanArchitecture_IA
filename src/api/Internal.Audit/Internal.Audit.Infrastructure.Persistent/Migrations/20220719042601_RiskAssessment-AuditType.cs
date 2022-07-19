using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RiskAssessmentAuditType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskAssesment_AuditType_AuditTypeId",
                schema: "BranchAudit",
                table: "RiskAssesment");

            migrationBuilder.DropTable(
                name: "AuditType",
                schema: "Config");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskAssesment_CommonValueAndType_AuditTypeId",
                schema: "BranchAudit",
                table: "RiskAssesment",
                column: "AuditTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetRiskAssessmentListProcedure]
     @pageSize int,
     @pageNumber int
AS
BEGIN
				SELECT ra.[Id]
					,ra.AssesmentCode
	                ,cntr.Id AS CountryId
	                ,cvtat.Id AS AuditTypeId
	                ,cntr.Name AS CountryName
	                ,cvtat.Text AS AuditTypeName
                    ,ra.[EffectiveFrom]
                    ,ra.[EffectiveTo]
                    ,ra.[CreatedBy]
                    ,ra.[CreatedOn]
                FROM [BranchAudit].[RiskAssesment] as ra
                INNER JOIN [common].[Country] as cntr on cntr.Id = ra.CountryId
				INNER JOIN [config].[CommonValueAndType] as cvtat on cvtat.Id = ra.AuditTypeId
				 WHERE  ra.IsDeleted = 0 ORDER BY ra.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
 SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[RiskAssesment] where [IsDeleted] = 0
    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskAssesment_CommonValueAndType_AuditTypeId",
                schema: "BranchAudit",
                table: "RiskAssesment");

            migrationBuilder.CreateTable(
                name: "AuditType",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ApprovedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RiskAssesment_AuditType_AuditTypeId",
                schema: "BranchAudit",
                table: "RiskAssesment",
                column: "AuditTypeId",
                principalSchema: "Config",
                principalTable: "AuditType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetRiskAssessmentListProcedure]");
        }
    }
}
