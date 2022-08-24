using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class createissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Issue",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AuditScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImpactTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikelihoodTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RatingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Policy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RootCause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessImpact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PotentialRisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditorRecommendation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Issue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issue_CommonValueAndType_ImpactTypeId",
                        column: x => x.ImpactTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Issue_CommonValueAndType_LikelihoodTypeId",
                        column: x => x.LikelihoodTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Issue_CommonValueAndType_RatingTypeId",
                        column: x => x.RatingTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Issue_CommonValueAndType_StatusTypeId",
                        column: x => x.StatusTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
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
                name: "IX_Issue_ImpactTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "ImpactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_LikelihoodTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "LikelihoodTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_RatingTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "RatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_StatusTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "StatusTypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Issue",
                schema: "BranchAudit");

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
        }
    }
}
