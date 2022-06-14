using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class UsertableDesignationremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Designation_DesignationId",
                schema: "Security",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_DesignationId",
                schema: "Security",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                schema: "Security",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DesignationId",
                schema: "Security",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_User_DesignationId",
                schema: "Security",
                table: "User",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Designation_DesignationId",
                schema: "Security",
                table: "User",
                column: "DesignationId",
                principalSchema: "Common",
                principalTable: "Designation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
