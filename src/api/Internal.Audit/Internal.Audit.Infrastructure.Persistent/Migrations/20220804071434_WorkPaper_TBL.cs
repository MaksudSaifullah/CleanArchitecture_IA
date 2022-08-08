using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class WorkPaper_TBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TopicHeadId",
                schema: "BranchAudit",
                table: "TopicHead",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkPaper",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    WorkPaperCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuditScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TopicHeadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SampleName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SampleMonthId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SampleSelectionMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlActivityNatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlFrequencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SampleSizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestingDetails = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TestingResults = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TestingConclusionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_WorkPaper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPaper_AuditSchedule_AuditScheduleId",
                        column: x => x.AuditScheduleId,
                        principalSchema: "BranchAudit",
                        principalTable: "AuditSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkPaper_CommonValueAndType_CommonValueAndTypeId",
                        column: x => x.CommonValueAndTypeId,
                        principalSchema: "Config",
                        principalTable: "CommonValueAndType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkPaper_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalSchema: "Common",
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicHead_TopicHeadId",
                schema: "BranchAudit",
                table: "TopicHead",
                column: "TopicHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPaper_AuditScheduleId",
                schema: "BranchAudit",
                table: "WorkPaper",
                column: "AuditScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPaper_CommonValueAndTypeId",
                schema: "BranchAudit",
                table: "WorkPaper",
                column: "CommonValueAndTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPaper_DocumentId",
                schema: "BranchAudit",
                table: "WorkPaper",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TopicHead_WorkPaper_TopicHeadId",
                schema: "BranchAudit",
                table: "TopicHead",
                column: "TopicHeadId",
                principalSchema: "BranchAudit",
                principalTable: "WorkPaper",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopicHead_WorkPaper_TopicHeadId",
                schema: "BranchAudit",
                table: "TopicHead");

            migrationBuilder.DropTable(
                name: "WorkPaper",
                schema: "BranchAudit");

            migrationBuilder.DropIndex(
                name: "IX_TopicHead_TopicHeadId",
                schema: "BranchAudit",
                table: "TopicHead");

            migrationBuilder.DropColumn(
                name: "TopicHeadId",
                schema: "BranchAudit",
                table: "TopicHead");
        }
    }
}
