using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RiskProfileFkRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfile_ImpactType_ImpactTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfile_LikelihoodType_LikelihoodTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfile_RatingType_RatingTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropTable(
                name: "ImpactType",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "LikelihoodType",
                schema: "Config");

            migrationBuilder.DropTable(
                name: "RatingType",
                schema: "Config");

            migrationBuilder.AddColumn<Guid>(
                name: "CommonValueAndTypeId",
                schema: "Common",
                table: "RiskProfile",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RiskProfile_CommonValueAndTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "CommonValueAndTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_CommonValueAndTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "CommonValueAndTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_ImpactTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "ImpactTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_LikelihoodTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "LikelihoodTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_RatingTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "RatingTypeId",
                principalSchema: "Config",
                principalTable: "CommonValueAndType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_CommonValueAndTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_ImpactTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_LikelihoodTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskProfile_CommonValueAndType_RatingTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropIndex(
                name: "IX_RiskProfile_CommonValueAndTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.DropColumn(
                name: "CommonValueAndTypeId",
                schema: "Common",
                table: "RiskProfile");

            migrationBuilder.CreateTable(
                name: "ImpactType",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ApprovedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LikelihoodType",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ApprovedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikelihoodType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RatingType",
                schema: "Config",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ApprovedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ReviewedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ReviewedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfile_ImpactType_ImpactTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "ImpactTypeId",
                principalSchema: "Config",
                principalTable: "ImpactType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfile_LikelihoodType_LikelihoodTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "LikelihoodTypeId",
                principalSchema: "Config",
                principalTable: "LikelihoodType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiskProfile_RatingType_RatingTypeId",
                schema: "Common",
                table: "RiskProfile",
                column: "RatingTypeId",
                principalSchema: "Config",
                principalTable: "RatingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
