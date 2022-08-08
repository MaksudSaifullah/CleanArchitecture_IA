using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RemovingdevpendencyfromTopicheadtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPaper_TopicHead_TopicHeadId1",
                schema: "BranchAudit",
                table: "WorkPaper");

            migrationBuilder.DropIndex(
                name: "IX_WorkPaper_TopicHeadId1",
                schema: "BranchAudit",
                table: "WorkPaper");

            migrationBuilder.DropColumn(
                name: "TopicHeadId1",
                schema: "BranchAudit",
                table: "WorkPaper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TopicHeadId1",
                schema: "BranchAudit",
                table: "WorkPaper",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkPaper_TopicHeadId1",
                schema: "BranchAudit",
                table: "WorkPaper",
                column: "TopicHeadId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPaper_TopicHead_TopicHeadId1",
                schema: "BranchAudit",
                table: "WorkPaper",
                column: "TopicHeadId1",
                principalSchema: "BranchAudit",
                principalTable: "TopicHead",
                principalColumn: "Id");
        }
    }
}
