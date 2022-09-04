using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class ClosingMeetingMinutesrelationupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClosingMeetingApologies_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingMeetingPresents_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingMeetingSubjects_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects");

            migrationBuilder.DropIndex(
                name: "IX_ClosingMeetingSubjects_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects");

            migrationBuilder.DropIndex(
                name: "IX_ClosingMeetingPresents_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents");

            migrationBuilder.DropIndex(
                name: "IX_ClosingMeetingApologies_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies");

            migrationBuilder.DropColumn(
                name: "ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects");

            migrationBuilder.DropColumn(
                name: "ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents");

            migrationBuilder.DropColumn(
                name: "ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingSubjects_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects",
                column: "ClosingMeetingMinutesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingPresents_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents",
                column: "ClosingMeetingMinutesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingApologies_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies",
                column: "ClosingMeetingMinutesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingMeetingApologies_ClosingMeetingMinutes_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies",
                column: "ClosingMeetingMinutesId",
                principalSchema: "BranchAudit",
                principalTable: "ClosingMeetingMinutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingMeetingPresents_ClosingMeetingMinutes_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents",
                column: "ClosingMeetingMinutesId",
                principalSchema: "BranchAudit",
                principalTable: "ClosingMeetingMinutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingMeetingSubjects_ClosingMeetingMinutes_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects",
                column: "ClosingMeetingMinutesId",
                principalSchema: "BranchAudit",
                principalTable: "ClosingMeetingMinutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClosingMeetingApologies_ClosingMeetingMinutes_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingMeetingPresents_ClosingMeetingMinutes_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClosingMeetingSubjects_ClosingMeetingMinutes_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects");

            migrationBuilder.DropIndex(
                name: "IX_ClosingMeetingSubjects_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects");

            migrationBuilder.DropIndex(
                name: "IX_ClosingMeetingPresents_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents");

            migrationBuilder.DropIndex(
                name: "IX_ClosingMeetingApologies_ClosingMeetingMinutesId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies");

            migrationBuilder.AddColumn<Guid>(
                name: "ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingSubjects_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects",
                column: "ClosingMeetingMinuteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingPresents_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents",
                column: "ClosingMeetingMinuteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClosingMeetingApologies_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies",
                column: "ClosingMeetingMinuteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingMeetingApologies_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingApologies",
                column: "ClosingMeetingMinuteId",
                principalSchema: "BranchAudit",
                principalTable: "ClosingMeetingMinutes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingMeetingPresents_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingPresents",
                column: "ClosingMeetingMinuteId",
                principalSchema: "BranchAudit",
                principalTable: "ClosingMeetingMinutes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosingMeetingSubjects_ClosingMeetingMinutes_ClosingMeetingMinuteId",
                schema: "BranchAudit",
                table: "ClosingMeetingSubjects",
                column: "ClosingMeetingMinuteId",
                principalSchema: "BranchAudit",
                principalTable: "ClosingMeetingMinutes",
                principalColumn: "Id");
        }
    }
}
