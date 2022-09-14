using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetChecklistListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetChecklistListProcedure]
@pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100)
AS
BEGIN
SELECT cl.[Id]
      ,cl.[ChecklistCode]
      ,cl.[AuditScheduleId]
      ,cl.[AuditScheduleBranchId]
	  ,brnch.BranchName
      ,cl.[CreatedBy]
      ,cl.[CreatedOn]
      ,cl.[IsDeleted]
  FROM [BranchAudit].[Checklists] cl
  Inner Join [BranchAudit].[ChecklistTopics] clt on clt.ChecklistId = cl.Id
  Inner Join [BranchAudit].[ChecklistTopicDetails] cltd on cltd.ChecklistTopicId = clt.Id
  INNER JOIN [security].[Branch] brnch on brnch.Id = cl.AuditScheduleBranchId
  WHERE cl.[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cl.[ChecklistCode] like '%'+@searchTerm+'%'))
     ORDER BY cl.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;

	SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[Checklists] as cl
		where cl.[IsDeleted] = 0
		AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cl.[ChecklistCode] like '%'+@searchTerm+'%'))

		END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetChecklistListProcedure]");
        }
    }
}
