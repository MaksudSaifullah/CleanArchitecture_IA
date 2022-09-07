using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetClosingMeetingMinutesListProcedure_Latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetClosingMeetingMinutesListProcedure]
@pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100)
AS
BEGIN
SELECT cmm.[Id]
      ,cmm.[MeetingMinutesCode]
      ,cmm.[MeetingMinutesDate]
      ,cmm.[MeetingMinutesName]
	  ,emp.[Name] as AgreedBy
      ,cmm.[AgreedByUserId]
      ,cmm.[CreatedOn]
  FROM [BranchAudit].[ClosingMeetingMinutes] cmm
  INNER JOIN [security].[Employee] emp on emp.UserId = cmm.AgreedByUserId
  INNER JOIN [security].[Branch] brnch on brnch.Id = cmm.AuditScheduleBranchId
   WHERE cmm.[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (brnch.BranchName like '%'+@searchTerm+'%'))
     ORDER BY cmm.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;

	SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[ClosingMeetingMinutes] as cmm
    INNER JOIN [security].[Branch] brnch on brnch.Id = cmm.AuditScheduleBranchId
		where cmm.[IsDeleted] = 0
		AND ((@searchTerm IS NULL OR @searchTerm = '') OR (brnch.BranchName like '%'+@searchTerm+'%'))

		END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetClosingMeetingMinutesListProcedure]");
        }
    }
}
