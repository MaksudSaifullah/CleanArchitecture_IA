using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class Datapullrequestsynctableschemachange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmbsDataSync_DataRequestQueueServices_DataRequestQueueServiceId",
                schema: "Security",
                table: "AmbsDataSync");

            migrationBuilder.DropForeignKey(
                name: "FK_DataRequestQueueServices_Country_CountryId",
                table: "DataRequestQueueServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataRequestQueueServices",
                table: "DataRequestQueueServices");

            migrationBuilder.RenameTable(
                name: "DataRequestQueueServices",
                newName: "DataRequestQueueService",
                newSchema: "Security");

            migrationBuilder.RenameIndex(
                name: "IX_DataRequestQueueServices_CountryId",
                schema: "Security",
                table: "DataRequestQueueService",
                newName: "IX_DataRequestQueueService_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataRequestQueueService",
                schema: "Security",
                table: "DataRequestQueueService",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmbsDataSync_DataRequestQueueService_DataRequestQueueServiceId",
                schema: "Security",
                table: "AmbsDataSync",
                column: "DataRequestQueueServiceId",
                principalSchema: "Security",
                principalTable: "DataRequestQueueService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataRequestQueueService_Country_CountryId",
                schema: "Security",
                table: "DataRequestQueueService",
                column: "CountryId",
                principalSchema: "common",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmbsDataSync_DataRequestQueueService_DataRequestQueueServiceId",
                schema: "Security",
                table: "AmbsDataSync");

            migrationBuilder.DropForeignKey(
                name: "FK_DataRequestQueueService_Country_CountryId",
                schema: "Security",
                table: "DataRequestQueueService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DataRequestQueueService",
                schema: "Security",
                table: "DataRequestQueueService");

            migrationBuilder.RenameTable(
                name: "DataRequestQueueService",
                schema: "Security",
                newName: "DataRequestQueueServices");

            migrationBuilder.RenameIndex(
                name: "IX_DataRequestQueueService_CountryId",
                table: "DataRequestQueueServices",
                newName: "IX_DataRequestQueueServices_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DataRequestQueueServices",
                table: "DataRequestQueueServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AmbsDataSync_DataRequestQueueServices_DataRequestQueueServiceId",
                schema: "Security",
                table: "AmbsDataSync",
                column: "DataRequestQueueServiceId",
                principalTable: "DataRequestQueueServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataRequestQueueServices_Country_CountryId",
                table: "DataRequestQueueServices",
                column: "CountryId",
                principalSchema: "common",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
