using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RemoverealtionshipIssue_CommonValuandType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issue_CommonValueAndType_ImpactTypeId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_CommonValueAndType_LikelihoodTypeId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_CommonValueAndType_RatingTypeId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_CommonValueAndType_StatusTypeId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_ImpactTypeId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_LikelihoodTypeId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_RatingTypeId",
                schema: "BranchAudit",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_Issue_StatusTypeId",
                schema: "BranchAudit",
                table: "Issue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Issue_CommonValueAndType_ImpactTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "ImpactTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_CommonValueAndType_LikelihoodTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "LikelihoodTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_CommonValueAndType_RatingTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "RatingTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_CommonValueAndType_StatusTypeId",
                schema: "BranchAudit",
                table: "Issue",
                column: "StatusTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");
        }
    }
}
