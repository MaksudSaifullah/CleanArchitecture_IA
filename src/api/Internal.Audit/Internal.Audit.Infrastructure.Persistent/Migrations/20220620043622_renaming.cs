using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class renaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureAction_Action_ActionId",
                schema: "Common",
                table: "FeatureAction");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureAction_Feature_FeatureId",
                schema: "Common",
                table: "FeatureAction");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureAction_Module_ModuleId",
                schema: "Common",
                table: "FeatureAction");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleFeature_Feature_FeatureId",
                schema: "Common",
                table: "ModuleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleFeature_Module_ModuleId",
                schema: "Common",
                table: "ModuleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAction_Action_ActionId",
                schema: "Security",
                table: "RoleAction");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleFeature_Feature_FeatureId",
                schema: "Security",
                table: "RoleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleModule_Module_ModuleId",
                schema: "Security",
                table: "RoleModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                schema: "Common",
                table: "Module");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feature",
                schema: "Common",
                table: "Feature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Action",
                schema: "Common",
                table: "Action");

            migrationBuilder.RenameTable(
                name: "Module",
                schema: "Common",
                newName: "AuditModule",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Feature",
                schema: "Common",
                newName: "AuditFeature",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "Action",
                schema: "Common",
                newName: "AuditAction",
                newSchema: "Common");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditModule",
                schema: "Common",
                table: "AuditModule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditFeature",
                schema: "Common",
                table: "AuditFeature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditAction",
                schema: "Common",
                table: "AuditAction",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DashBoardBase",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
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
                    table.PrimaryKey("PK_DashBoardBase", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureAction_AuditAction_ActionId",
                schema: "Common",
                table: "FeatureAction",
                column: "ActionId",
                principalSchema: "Common",
                principalTable: "AuditAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureAction_AuditFeature_FeatureId",
                schema: "Common",
                table: "FeatureAction",
                column: "FeatureId",
                principalSchema: "Common",
                principalTable: "AuditFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureAction_AuditModule_ModuleId",
                schema: "Common",
                table: "FeatureAction",
                column: "ModuleId",
                principalSchema: "Common",
                principalTable: "AuditModule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleFeature_AuditFeature_FeatureId",
                schema: "Common",
                table: "ModuleFeature",
                column: "FeatureId",
                principalSchema: "Common",
                principalTable: "AuditFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleFeature_AuditModule_ModuleId",
                schema: "Common",
                table: "ModuleFeature",
                column: "ModuleId",
                principalSchema: "Common",
                principalTable: "AuditModule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAction_AuditAction_ActionId",
                schema: "Security",
                table: "RoleAction",
                column: "ActionId",
                principalSchema: "Common",
                principalTable: "AuditAction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFeature_AuditFeature_FeatureId",
                schema: "Security",
                table: "RoleFeature",
                column: "FeatureId",
                principalSchema: "Common",
                principalTable: "AuditFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModule_AuditModule_ModuleId",
                schema: "Security",
                table: "RoleModule",
                column: "ModuleId",
                principalSchema: "Common",
                principalTable: "AuditModule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureAction_AuditAction_ActionId",
                schema: "Common",
                table: "FeatureAction");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureAction_AuditFeature_FeatureId",
                schema: "Common",
                table: "FeatureAction");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureAction_AuditModule_ModuleId",
                schema: "Common",
                table: "FeatureAction");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleFeature_AuditFeature_FeatureId",
                schema: "Common",
                table: "ModuleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleFeature_AuditModule_ModuleId",
                schema: "Common",
                table: "ModuleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleAction_AuditAction_ActionId",
                schema: "Security",
                table: "RoleAction");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleFeature_AuditFeature_FeatureId",
                schema: "Security",
                table: "RoleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleModule_AuditModule_ModuleId",
                schema: "Security",
                table: "RoleModule");

            migrationBuilder.DropTable(
                name: "DashBoardBase",
                schema: "Common");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditModule",
                schema: "Common",
                table: "AuditModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditFeature",
                schema: "Common",
                table: "AuditFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditAction",
                schema: "Common",
                table: "AuditAction");

            migrationBuilder.RenameTable(
                name: "AuditModule",
                schema: "Common",
                newName: "Module",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "AuditFeature",
                schema: "Common",
                newName: "Feature",
                newSchema: "Common");

            migrationBuilder.RenameTable(
                name: "AuditAction",
                schema: "Common",
                newName: "Action",
                newSchema: "Common");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                schema: "Common",
                table: "Module",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feature",
                schema: "Common",
                table: "Feature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Action",
                schema: "Common",
                table: "Action",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureAction_Action_ActionId",
                schema: "Common",
                table: "FeatureAction",
                column: "ActionId",
                principalSchema: "Common",
                principalTable: "Action",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureAction_Feature_FeatureId",
                schema: "Common",
                table: "FeatureAction",
                column: "FeatureId",
                principalSchema: "Common",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureAction_Module_ModuleId",
                schema: "Common",
                table: "FeatureAction",
                column: "ModuleId",
                principalSchema: "Common",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleFeature_Feature_FeatureId",
                schema: "Common",
                table: "ModuleFeature",
                column: "FeatureId",
                principalSchema: "Common",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleFeature_Module_ModuleId",
                schema: "Common",
                table: "ModuleFeature",
                column: "ModuleId",
                principalSchema: "Common",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleAction_Action_ActionId",
                schema: "Security",
                table: "RoleAction",
                column: "ActionId",
                principalSchema: "Common",
                principalTable: "Action",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleFeature_Feature_FeatureId",
                schema: "Security",
                table: "RoleFeature",
                column: "FeatureId",
                principalSchema: "Common",
                principalTable: "Feature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleModule_Module_ModuleId",
                schema: "Security",
                table: "RoleModule",
                column: "ModuleId",
                principalSchema: "Common",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
