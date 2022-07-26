using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class auditfrequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditFrequency",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditScoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditFrequencyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommonValueAndTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AuditFrequency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditFrequency_CommonValueAndType_AuditFrequencyTypeId",
                        column: x => x.AuditFrequencyTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditFrequency_CommonValueAndType_AuditScoreId",
                        column: x => x.AuditScoreId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditFrequency_CommonValueAndType_CommonValueAndTypeId",
                        column: x => x.CommonValueAndTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditFrequency_CommonValueAndType_RatingTypeId",
                        column: x => x.RatingTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditFrequency_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "common",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditFrequency_AuditFrequencyTypeId",
                schema: "BranchAudit",
                table: "AuditFrequency",
                column: "AuditFrequencyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditFrequency_AuditScoreId",
                schema: "BranchAudit",
                table: "AuditFrequency",
                column: "AuditScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditFrequency_CommonValueAndTypeId",
                schema: "BranchAudit",
                table: "AuditFrequency",
                column: "CommonValueAndTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditFrequency_CountryId",
                schema: "BranchAudit",
                table: "AuditFrequency",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditFrequency_RatingTypeId",
                schema: "BranchAudit",
                table: "AuditFrequency",
                column: "RatingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditFrequency",
                schema: "BranchAudit");
        }
    }
}
