using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class CreateissueActionPlanOwnerupdateissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Config",
                table: "IssueOwner");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "BranchAudit",
                table: "IssueBranch");

            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.CreateTable(
                name: "IssueActionPlan",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ActionPlanCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EvidenceDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManagementPlan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TargetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActionTaken = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    ActionTakenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActionTakenRemarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_IssueActionPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueActionPlan_Issue_IssueId",
                        column: x => x.IssueId,
                        principalSchema: "BranchAudit",
                        principalTable: "Issue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueActionPlanOwner",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IssueActionPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_IssueActionPlanOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueActionPlanOwner_IssueActionPlan_IssueActionPlanId",
                        column: x => x.IssueActionPlanId,
                        principalSchema: "BranchAudit",
                        principalTable: "IssueActionPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueActionPlan_IssueId",
                schema: "BranchAudit",
                table: "IssueActionPlan",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueActionPlanOwner_IssueActionPlanId",
                schema: "BranchAudit",
                table: "IssueActionPlanOwner",
                column: "IssueActionPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueActionPlanOwner",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "IssueActionPlan",
                schema: "BranchAudit");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Config",
                table: "IssueOwner",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "BranchAudit",
                table: "IssueBranch",
                type: "bit",
                nullable: false,
                defaultValueSql: "1");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                schema: "BranchAudit",
                table: "Issue",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
