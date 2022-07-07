using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class ModulewiseRolePrivilegetableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModulewiseRolePriviliege",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    AuditModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuditFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false),
                    IsCreate = table.Column<bool>(type: "bit", nullable: false),
                    IsEdit = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ModulewiseRolePriviliege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModulewiseRolePriviliege_AuditFeature_AuditFeatureId",
                        column: x => x.AuditFeatureId,
                        principalSchema: "Common",
                        principalTable: "AuditFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulewiseRolePriviliege_AuditModule_AuditModuleId",
                        column: x => x.AuditModuleId,
                        principalSchema: "Common",
                        principalTable: "AuditModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulewiseRolePriviliege_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModulewiseRolePriviliege_AuditFeatureId",
                schema: "Security",
                table: "ModulewiseRolePriviliege",
                column: "AuditFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulewiseRolePriviliege_AuditModuleId",
                schema: "Security",
                table: "ModulewiseRolePriviliege",
                column: "AuditModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulewiseRolePriviliege_RoleId",
                schema: "Security",
                table: "ModulewiseRolePriviliege",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulewiseRolePriviliege",
                schema: "Security");
        }
    }
}
