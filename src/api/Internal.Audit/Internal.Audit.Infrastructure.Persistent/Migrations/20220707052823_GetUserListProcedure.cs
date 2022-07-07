using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetUserListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[GetUserListProcedure]
									 @userName nvarchar(50),
									 @employeeName nvarchar(50),
									 @roleName nvarchar(50),
									 @pageSize int,
									 @pageNumber int
								AS
								BEGIN


								SELECT * INTO #TempRole FROM [security].[Role] r WHERE (@roleName is null or @roleName = '') or  r.Name like '%'+@roleName+'%'

								SELECT * INTO #TempResult FROM (
									SELECT
									usr.Id
									,emp.Email,usr.[Password], usr.UserName
									,(SELECT
										STUFF((SELECT ', ' + CAST(c.name AS nVARCHAR(max)) 
										FROM [security].[UserCountry]
										INNER JOIN [common].[Country] c on c.Id=[UserCountry].CountryId
										WHERE UserId=usr.Id
										FOR XML PATH(''), TYPE)
										.value('.','NVARCHAR(MAX)'),1,2,' ')) as Entity
									,emp.[Name] as EmployeeName
									,(SELECT
										STUFF((SELECT ', ' + CAST(r.name AS nVARCHAR(max)) 
										FROM [security].[UserRole]
										INNER JOIN [security].[Role] r on r.Id=[UserRole].RoleId
										WHERE UserId=usr.Id
										FOR XML PATH(''), TYPE)
										.value('.','NVARCHAR(MAX)'),1,2,' ')) UserRole
									,dg.Name [Designation]
									,usr.IsEnabled
									,usr.IsAccountExpired,
									usr.IsPasswordExpired
									,usr.IsAccountLocked
									FROM [security].[User] as usr
									INNER JOIN [security].[Employee] emp on usr.Id=emp.UserId
									INNER JOIN [common].[Designation] dg on dg.Id=emp.[DesignationId]
									INNER JOIN [security].[UserRole] ur on ur.UserId=usr.Id
									INNER JOIN #TempRole r on r.Id=ur.RoleId
									group by usr.Id
									,emp.Email,usr.[Password], usr.UserName,emp.[Name] ,dg.Name
									,usr.IsEnabled
									,usr.IsAccountExpired,
									usr.IsPasswordExpired
									,usr.IsAccountLocked
								) X
								WHERE ((@userName is null or @userName = '') or X.UserName like '%'+@userName+'%')
								AND ((@employeeName is null or @employeeName  = '') or X.EmployeeName like '%'+@employeeName+'%')


								SELECT * from #TempResult 
								ORDER BY #TempResult.UserName DESC
								OFFSET ((@pageNumber-1) * @pageSize) ROWS
								FETCH NEXT @pageSize ROWS ONLY;

								SELECT cast(count(*) as bigint) as TotalCount from #TempResult



								END
								");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP PROCEDURE dbo.[GetUserListProcedure] ");
		}
    }
}
