using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class notificationtoAuditee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationToAuditee",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    AuditCreationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_NotificationToAuditee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationToAuditee_AuditCreation_AuditCreationId",
                        column: x => x.AuditCreationId,
                        principalSchema: "BranchAudit",
                        principalTable: "AuditCreation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotifedUsersBCC",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationToAuditeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_NotifedUsersBCC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifedUsersBCC_NotificationToAuditee_NotificationToAuditeeId",
                        column: x => x.NotificationToAuditeeId,
                        principalSchema: "BranchAudit",
                        principalTable: "NotificationToAuditee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotifedUsersBCC_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotifedUsersCC",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationToAuditeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_NotifedUsersCC", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifedUsersCC_NotificationToAuditee_NotificationToAuditeeId",
                        column: x => x.NotificationToAuditeeId,
                        principalSchema: "BranchAudit",
                        principalTable: "NotificationToAuditee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotifedUsersCC_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotifedUsersTo",
                schema: "BranchAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationToAuditeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_NotifedUsersTo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotifedUsersTo_NotificationToAuditee_NotificationToAuditeeId",
                        column: x => x.NotificationToAuditeeId,
                        principalSchema: "BranchAudit",
                        principalTable: "NotificationToAuditee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotifedUsersTo_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotifedUsersBCC_NotificationToAuditeeId",
                schema: "BranchAudit",
                table: "NotifedUsersBCC",
                column: "NotificationToAuditeeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifedUsersBCC_UserId",
                schema: "BranchAudit",
                table: "NotifedUsersBCC",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifedUsersCC_NotificationToAuditeeId",
                schema: "BranchAudit",
                table: "NotifedUsersCC",
                column: "NotificationToAuditeeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifedUsersCC_UserId",
                schema: "BranchAudit",
                table: "NotifedUsersCC",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifedUsersTo_NotificationToAuditeeId",
                schema: "BranchAudit",
                table: "NotifedUsersTo",
                column: "NotificationToAuditeeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotifedUsersTo_UserId",
                schema: "BranchAudit",
                table: "NotifedUsersTo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationToAuditee_AuditCreationId",
                schema: "BranchAudit",
                table: "NotificationToAuditee",
                column: "AuditCreationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotifedUsersBCC",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "NotifedUsersCC",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "NotifedUsersTo",
                schema: "BranchAudit");

            migrationBuilder.DropTable(
                name: "NotificationToAuditee",
                schema: "BranchAudit");
        }
    }
}
