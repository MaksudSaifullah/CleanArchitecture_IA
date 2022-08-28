using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class ClosingMeetingMinutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClosingMeetingMinutes",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    MeetingMinutesCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuditScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingMinutesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingMinutesName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AuditOn = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    MeetingHeld = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PreparedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgreedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ClosingMeetingMinutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClosingMeetingApologies",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingMeetingMinutesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingMeetingMinuteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ClosingMeetingApologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClosingMeetingApologies_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                        column: x => x.ClosingMeetingMinuteId,
                        principalSchema: "BranchAudit",
                        principalTable: "ClosingMeetingMinutes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClosingMeetingApologies_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClosingMeetingPresents",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingMeetingMinutesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingMeetingMinuteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ClosingMeetingPresents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClosingMeetingPresents_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                        column: x => x.ClosingMeetingMinuteId,
                        principalSchema: "BranchAudit",
                        principalTable: "ClosingMeetingMinutes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClosingMeetingPresents_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClosingMeetingSubjects",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingMeetingMinutesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectMatter = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClosingMeetingMinuteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ClosingMeetingSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClosingMeetingSubjects_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                        column: x => x.ClosingMeetingMinuteId,
                        principalSchema: "BranchAudit",
                        principalTable: "ClosingMeetingMinutes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClosingMeetingSubjects_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingApologies_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies",
                column: "ClosingMeetingMinuteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingApologies_UserId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingPresents_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents",
                column: "ClosingMeetingMinuteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingPresents_UserId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingSubjects_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects",
                column: "ClosingMeetingMinuteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingSubjects_UserId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClosingMeetingApologies",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "ClosingMeetingPresents",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "ClosingMeetingSubjects",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "ClosingMeetingMinutes",
                schema: "BranchAudit");
        }
    }
}
