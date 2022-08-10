using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class MasterSPmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"CREATE or ALTER PROCEDURE [dbo].[GetUserByIdProcedure]
	 @userId nvarchar(50)
AS
BEGIN


--SELECT * INTO #TempRole FROM [security].[Role] r WHERE @roleName is null or  r.Name=@roleName

SELECT * FROM (
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
    --INNER JOIN #TempRole r on r.Id=ur.RoleId
	group by usr.Id
	,emp.Email,usr.[Password], usr.UserName,emp.[Name] ,dg.Name
	,usr.IsEnabled
	,usr.IsAccountExpired,
	usr.IsPasswordExpired
	,usr.IsAccountLocked
) X
WHERE X.Id=@userId
--(@userName is null or X.UserName=@userName)
--AND (@employeeName is null or X.EmployeeName=@employeeName)

END");
			migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetDesignationListProcedure]
	        @pageSize int,
	        @pageNumber int,
	        @searchTerm nvarchar(100)
	 
            AS
            BEGIN
	            SELECT [Id]
	                ,[Name]
                    ,[Description]
                    ,[IsActive]
                    ,[CreatedBy]
                    ,[CreatedOn]
	                FROM [common].[Designation]
	                WHERE [IsDeleted] = 0
	            AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Designation.Name like '%'+@searchTerm+'%') OR (Designation.Description like '%'+@searchTerm+'%'))	

	                ORDER BY [CreatedOn] DESC
	                OFFSET ((@pageNumber-1) * @pageSize) ROWS
	                FETCH NEXT @pageSize ROWS ONLY;


	            SELECT cast(count(*) as bigint) as TotalCount from [common].[Designation] where [IsDeleted] = 0 
	            AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Designation.Name like '%'+@searchTerm+'%') OR (Designation.Description like '%'+@searchTerm+'%'))	

            END");
			migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetCountryListProcedure]
     @pageSize int,
     @pageNumber int,
	  @searchTerm nvarchar(100)
AS
BEGIN
       SELECT
       [Id]
      ,[Name]
      ,[Code]
      ,[Remarks]
      ,[CreatedBy]
      ,[CreatedOn]
     FROM[common].[Country]
     WHERE[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Country.Code like '%'+@searchTerm+'%'))	
     ORDER BY[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
 SELECT cast(count(*) as bigint) as TotalCount from[common].[Country] where[IsDeleted] = 0
 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Country.Code like '%'+@searchTerm+'%'))	
END");
			migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetRiskProfileListProcedure]
                 @pageSize int,
                 @pageNumber int,
	             @searchTerm nvarchar(100)
                    AS
                    BEGIN
                           SELECT
	                         rp.[Id]
	                        ,cvtlt.Text AS LikelihoodType
	                        ,cvtit.Text AS ImpactType
	                        ,cvtrt.Text AS RatingType
                            ,rp.[EffectiveFrom]
                            ,rp.[EffectiveTo]
                            ,rp.[Description]
                            ,rp.[CreatedBy]
                            ,rp.[CreatedOn]
		                    ,rp.[IsActive]
                         FROM[common].[RiskProfile] as rp
	                        INNER JOIN [config].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                         WHERE rp.[IsDeleted] = 0
	                     AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtlt.Text like '%'+@searchTerm+'%') OR (cvtit.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%'))	
                         ORDER BY rp.[CreatedOn] DESC
                         OFFSET((@pageNumber - 1) * @pageSize) ROWS
                         FETCH NEXT @pageSize ROWS ONLY;

                     SELECT cast(count(*) as bigint) as TotalCount from[common].[RiskProfile] as rp
		                    INNER JOIN [config].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                     where rp.[IsDeleted] = 0
                     AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtlt.Text like '%'+@searchTerm+'%') OR (cvtit.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%'))	
                    END     ");
            migrationBuilder.Sql(@"CREATE OR ALTER     PROCEDURE [dbo].[GetModulewiseRolePriviliegeByRoleIdListProcedure]
            @pageSize int,
            @pageNumber int,
            @roleId nvarchar(36)
            AS
            BEGIN
            SELECT [Id]
            ,[AuditModuleId]
            ,[AuditFeatureId]
            ,[RoleId]
            ,[IsView]
            ,[IsCreate]
            ,[IsEdit]
            ,[IsDelete]
            FROM [security].[ModulewiseRolePriviliege]
            WHERE [IsDeleted] = 0 and [RoleId]=@roleId
            ORDER BY [CreatedOn] DESC
            OFFSET ((@pageNumber-1) * @pageSize) ROWS
            FETCH NEXT @pageSize ROWS ONLY;


            SELECT cast(count(*) as bigint) as TotalCount from [security].[ModulewiseRolePriviliege] where [IsDeleted] = 0

            END");
            migrationBuilder.Sql(@"CREATE OR ALTER     PROCEDURE [dbo].[GetModulewiseRolePriviliegeListProcedure]
            @pageSize int,
            @pageNumber int            
            AS
            BEGIN
            SELECT [Id]
            ,[AuditModuleId]
            ,[AuditFeatureId]
            ,[RoleId]
            ,[IsView]
            ,[IsCreate]
            ,[IsEdit]
            ,[IsDelete]
            FROM [security].[ModulewiseRolePriviliege]
            WHERE [IsDeleted] = 0 
            ORDER BY [CreatedOn] DESC
            OFFSET ((@pageNumber-1) * @pageSize) ROWS
            FETCH NEXT @pageSize ROWS ONLY;


            SELECT cast(count(*) as bigint) as TotalCount from [security].[ModulewiseRolePriviliege] where [IsDeleted] = 0

            END");
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetRiskCriteriaListProcedure]
     @pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100)
AS
BEGIN
       SELECT
	     rc.[Id]
		 ,cntr.Id AS CountryId
		 ,cntr.Name AS CountryName
	    ,cvtct.Text AS RiskCriteriaType
		,rc.[MinimumValue]
		,rc.[MaximumValue]
	    ,cvtrt.Text AS RatingType
		,rc.[Score]
        ,rc.[EffectiveFrom]
        ,rc.[EffectiveTo]
        ,rc.[Description]
        ,rc.[CreatedBy]
        ,rc.[CreatedOn]		
        FROM[BranchAudit].[RiskCriteria] as rc
	    INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId 
	    INNER JOIN [config].[CommonValueAndType] as cvtct on cvtct.Id = rc.RiskCriteriaTypeId      
        INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rc.RatingTypeId
     WHERE rc.[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtct.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%') OR (cntr.[Name] like '%'+@searchTerm+'%'))	
     ORDER BY rc.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
	SELECT cast(count(*) as bigint) as TotalCount from[BranchAudit].[RiskCriteria] as rc
		INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId 
	    INNER JOIN [config].[CommonValueAndType] as cvtct on cvtct.Id = rc.RiskCriteriaTypeId      
        INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rc.RatingTypeId
		where rc.[IsDeleted] = 0
		AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtct.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%') OR (cntr.[Name] like '%'+@searchTerm+'%'))
		END");
            migrationBuilder.Sql(@" CREATE OR  ALTER     PROCEDURE [dbo].[GetTopicHeadListProcedure]
                 @pageSize int,
                 @pageNumber int,
	             @searchTerm nvarchar(100)
            AS
            BEGIN
                   SELECT
	                 topicHead.[Id]
		            ,topicHead.[CountryId]
		            ,topicHead.[Name]
		            ,topicHead.[EffectiveFrom]
		            ,topicHead.[EffectiveTo]
		            ,topicHead.[Description]
                    ,Country.[Name] AS CountryName
        	
		            FROM [BranchAudit].[TopicHead] as topicHead
	                INNER JOIN [common].Country as Country on Country.Id = topicHead.CountryId       
		            WHERE topicHead.IsDeleted = 0
		            AND ((@searchTerm IS NULL OR @searchTerm = '') OR (topicHead.[Name] like '%'+@searchTerm+'%') OR (Country.[Name] like '%'+@searchTerm+'%'))	

                 ORDER BY topicHead.CreatedOn DESC
                 OFFSET((@pageNumber - 1) * @pageSize) ROWS
                 FETCH NEXT @pageSize ROWS ONLY;
             SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[TopicHead] as topicHead
             INNER JOIN [common].Country as Country on Country.Id = topicHead.CountryId
             where topicHead.[IsDeleted]=0 
             AND ((@searchTerm IS NULL OR @searchTerm = '') OR (topicHead.[Name] like '%'+@searchTerm+'%') OR (Country.[Name] like '%'+@searchTerm+'%'))	
            END");
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetEmailConfigListProcedure]
	                                 @pageSize int,
	                                 @pageNumber int,
	                                 @searchTerm nvarchar(50)
                                AS
                                BEGIN

                                SELECT a.Id,a.EmailTypeId,a.CountryId,b.Name[EmailTypeName],c.Name[CountryName],a.TemplateSubject,a.TemplateBody,a.CreatedOn
                                FROM [Config].[EmailConfiguration] a
                                INNER JOIN Config.EmailType b on a.EmailTypeId=b.Id
                                INNER JOIN common.Country c on a.CountryId=c.Id
                                WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or c.[Name] like '%'+@searchTerm+'%')
                                ORDER BY c.Name ASC
                                OFFSET ((@pageNumber-1) * @pageSize) ROWS
                                FETCH NEXT @pageSize ROWS ONLY;

                                SELECT cast(count(*) as bigint) as TotalCount from [Config].[EmailConfiguration]  WHERE IsDeleted=0

                                END");
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetEmailTypeListProcedure]
	                                 @pageSize int,
	                                 @pageNumber int
                                AS
                                BEGIN

                                SELECT *
                                FROM [Config].[EmailType] a
                                WHERE a.IsDeleted=0
                                ORDER BY Id DESC
                                OFFSET ((@pageNumber-1) * @pageSize) ROWS
                                FETCH NEXT @pageSize ROWS ONLY;

                                SELECT cast(count(*) as bigint) as TotalCount from [Config].[EmailType]

                                END");
			migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetUserListProcedure]
			@userName nvarchar(50),
			@employeeName nvarchar(50),
			@roleName nvarchar(50),
			@pageSize int,
			@pageNumber int
	AS
	BEGIN

	SELECT * INTO #TempRole FROM [security].[Role] r WHERE (@roleName is null or @roleName = '') or  r.Name like '%'+@roleName+'%'

	SELECT * INTO #TempResult FROM (
		SELECT distinct
		usr.Id
		, emp.Email, usr.[Password], usr.UserName
		, (SELECT
			STUFF((SELECT ', ' + CAST(c.name AS nVARCHAR(max))
			FROM[security].[UserCountry]
			INNER JOIN[common].[Country] c on c.Id =[UserCountry].CountryId
			WHERE UserId = usr.Id
			FOR XML PATH(''), TYPE)
			.value('.', 'NVARCHAR(MAX)'), 1, 2, ' ')) as Entity
		,COUNT(distinct uc.CountryId) EntityCount, emp.[Name] as EmployeeName
		,(SELECT
			STUFF((SELECT ', ' + CAST(r.name AS nVARCHAR(max))
			FROM[security].[UserRole]
			INNER JOIN[security].[Role] r on r.Id =[UserRole].RoleId
			WHERE UserId = usr.Id
			FOR XML PATH(''), TYPE)
			.value('.', 'NVARCHAR(MAX)'),1,2,' ')) UserRole
		,dg.Name[Designation]
		,usr.IsEnabled
		,usr.IsAccountExpired,
		usr.IsPasswordExpired
		,usr.IsAccountLocked
		,usr.IsDeleted
		,usr.CreatedOn
		FROM[security].[User] as usr
		INNER JOIN[security].[UserCountry] uc on usr.Id = uc.UserId
		INNER JOIN[security].[Employee] emp on usr.Id = emp.UserId
		INNER JOIN[common].[Designation] dg on dg.Id = emp.[DesignationId]
		INNER JOIN[security].[UserRole] ur on ur.UserId = usr.Id
		INNER JOIN #TempRole r on r.Id=ur.RoleId
		group by usr.Id
		,emp.Email,usr.[Password], usr.UserName,emp.[Name] ,dg.Name
		,usr.IsEnabled
		,usr.IsAccountExpired,
		usr.IsPasswordExpired
		,usr.IsAccountLocked
		,usr.IsDeleted
		,usr.CreatedOn
		,uc.UserId
	) X
	WHERE((@userName is null or @userName = '') or X.UserName like '%' + @userName + '%')
	AND((@employeeName is null or @employeeName = '') or X.EmployeeName like '%' + @employeeName + '%')


	SELECT* from #TempResult a
	WHERE a.IsDeleted = 0
	ORDER BY a.CreatedOn DESC
	OFFSET((@pageNumber - 1) * @pageSize) ROWS
	 FETCH NEXT @pageSize ROWS ONLY;

			SELECT cast(count(*) as bigint) as TotalCount from #TempResult x where x.IsDeleted=0

	END");
			migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetAuditListProcedure]
	    @pageSize int,
	    @pageNumber int,
	    @searchTerm nvarchar(50)
AS
BEGIN

SELECT a.Id,a.AuditTypeId,ra.CountryId,ap.PlanCode as PlanId,a.AuditId,a.AuditName,b.Text[AuditTypeName],c.Name[CountryName],
a.Year, a.AuditPeriodFrom,a.AuditPeriodTo,a.CreatedOn,IIF(aa.Id is not null,1,0) ScheduleExists
FROM [BranchAudit].[AuditCreation] a
INNER JOIN [BranchAudit].AuditPlan ap on a.AuditPlanId=ap.Id
INNER JOIN [BranchAudit].[RiskAssessment] ra on ap.RiskAssessmentId=ra.Id
INNER JOIN Config.CommonValueAndType b on a.AuditTypeId=b.Id
INNER JOIN common.Country c on ra.CountryId=c.Id
LEFT JOIN [BranchAudit].[AuditSchedule] aa on aa.AuditCreationId=a.Id
WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or a.AuditId like '%'+@searchTerm+'%')
ORDER BY c.CreatedOn DESC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditCreation] where IsDeleted=0

END
");
			migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetAuditFrequencyListProcedure]
     @pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100)
AS
BEGIN
       SELECT
	    af.[Id]
		,cntr.Id AS CountryId
		,cntr.Name AS CountryName
	    ,cvtas.Text AS AuditScore
	    ,cvtrt.Text AS RatingType
		,cvtaf.Text AS AuditFrequencyType
        ,af.[EffectiveFrom]
        ,af.[EffectiveTo]
        ,af.[CreatedBy]
        ,af.[CreatedOn]		
        FROM[BranchAudit].[AuditFrequency] as af
	    INNER JOIN [common].[Country] as cntr on cntr.Id = af.CountryId 
	    INNER JOIN [config].[CommonValueAndType] as cvtas on cvtas.Id = af.AuditScoreId      
        INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = af.RatingTypeId
		INNER JOIN [config].[CommonValueAndType] as cvtaf on cvtaf.Id = af.AuditFrequencyTypeId
     WHERE af.[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtas.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%') OR (cvtaf.Text like '%'+@searchTerm+'%'))	
     ORDER BY af.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
	 SELECT cast(count(*) as bigint) as TotalCount from[BranchAudit].[AuditFrequency] as af
		INNER JOIN [common].[Country] as cntr on cntr.Id = af.CountryId 
	    INNER JOIN [config].[CommonValueAndType] as cvtas on cvtas.Id = af.AuditScoreId      
        INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = af.RatingTypeId
		INNER JOIN [config].[CommonValueAndType] as cvtaf on cvtaf.Id = af.AuditFrequencyTypeId
		 WHERE af.[IsDeleted] = 0
 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtas.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%') OR (cvtaf.Text like '%'+@searchTerm+'%'))	
END");
			migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetRoleListProcedure]
                        @pageSize int,
                        @pageNumber int,
						@searchTerm nvarchar(100)
                        AS
                        BEGIN
                        SELECT [Id]
                        ,[Name]
                        ,[Description]
                        ,[IsActive]
                        FROM [security].[Role]
                        WHERE [IsDeleted] = 0
						AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Role.Name like '%'+@searchTerm+'%') OR (Role.Description like '%'+@searchTerm+'%'))	
                        ORDER BY [CreatedOn] DESC
                        OFFSET((@pageNumber - 1) * @pageSize) ROWS
                        FETCH NEXT @pageSize ROWS ONLY;
                        SELECT cast(count(*) as bigint) as TotalCount from [security].[Role] where [IsDeleted] = 0
						AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Role.Name like '%'+@searchTerm+'%') OR (Role.Description like '%'+@searchTerm+'%'))	
                        END
");
			migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetQuestionnaireListProcedure]
				 @pageSize int,
				 @pageNumber int,
				 @searchTerm nvarchar(100)
					AS
					BEGIN
						   SELECT
								 Questionnaire.[Id]
								,TopicHead.Name AS TopicHead
								,Country.Name AS Country
								,Questionnaire.Question
								,Questionnaire.EffectiveFrom
								,Questionnaire.EffectiveTo
								,Questionnaire.IsActive
						 FROM BranchAudit.Questionnaire as Questionnaire
							 INNER JOIN BranchAudit.TopicHead as TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							 INNER JOIN common.Country as Country on Country.Id = TopicHead.CountryId
							 WHERE Questionnaire.IsDeleted = 0
							 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%'))	
							 ORDER BY Questionnaire.[CreatedOn] DESC
							 OFFSET((@pageNumber - 1) * @pageSize) ROWS
							 FETCH NEXT @pageSize ROWS ONLY;

					 SELECT cast(count(*) as bigint) as TotalCount from BranchAudit.Questionnaire as Questionnaire
							INNER JOIN BranchAudit.TopicHead as TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							INNER JOIN common.Country as Country on Country.Id = TopicHead.CountryId
							WHERE Questionnaire.IsDeleted = 0
							AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%'))	
					END");
			migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetWeightScoreProcedure]
                                    @pageSize INT,
                                    @pageNumber INT,
									 @searchTerm nvarchar(100)


                                    AS
                                    BEGIN
                                         SELECT c.Name AS CountryName, th.Name AS TopicHeadName, ws.* 
                                         FROM [BranchAudit].[WeightScore] AS ws
                                         JOIN [BranchAudit].[TopicHead] AS th ON th.Id = ws.TopicHeadId
                                         JOIN [common].[Country] AS c ON c.Id = th.CountryId
										 WHERE ws.[IsDeleted] = 0
										 --AND ((@searchTerm IS NULL OR @searchTerm = '') OR (c.Name like '%'+@searchTerm+'%') OR (c.Code like '%'+@searchTerm+'%'))	
                                         ORDER BY[CreatedOn] DESC
                                         OFFSET((@pageNumber - 1) * @pageSize) ROWS
                                         FETCH NEXT @pageSize ROWS ONLY;
                                         SELECT CAST(COUNT(*) AS BIGINT) AS TotalCount FROM [BranchAudit].[WeightScore] WHERE [IsDeleted] = 0
                                    END");
			migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetAuditPlanCodeListProcedure]
	                                 @pageSize int,
	                                 @pageNumber int,
									 @countryId uniqueidentifier,
									 @auditTypeId uniqueidentifier
AS
BEGIN

SELECT ap.Id,ap.PlanCode
from [BranchAudit].[RiskAssessment] ra
INNER JOIN [BranchAudit].[AuditPlan] ap on ap.RiskAssessmentId=ra.Id
WHERE ap.IsDeleted=0 and ra.CountryId=@countryId and ra.AuditTypeId=@auditTypeId

ORDER BY Id DESC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditPlan] where IsDeleted=0

END");
			migrationBuilder.Sql(@"CREATE OR  ALTER   PROCEDURE [dbo].[GetRiskAssessmentListProcedure]
     @pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100),
	 @year nvarchar(50)
AS
BEGIN
				SELECT ra.[Id]
					,ra.AssessmentCode
	                ,cntr.Id AS CountryId
	                ,cvtat.Id AS AuditTypeId
	                ,cntr.Name AS CountryName
	                ,cvtat.Text AS AuditTypeName
                    ,ra.[EffectiveFrom]
                    ,ra.[EffectiveTo]
                    ,ra.[CreatedBy]
                    ,ra.[CreatedOn]
                FROM [BranchAudit].[RiskAssessment] as ra
                INNER JOIN [common].[Country] as cntr on cntr.Id = ra.CountryId
				INNER JOIN [config].[CommonValueAndType] as cvtat on cvtat.Id = ra.AuditTypeId
				 WHERE  ra.IsDeleted = 0
				 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (ra.AssessmentCode like '%'+@searchTerm+'%'))	
				 AND ((@year IS NULL OR @year = '') OR (ra.EffectiveFrom like '%'+@year+'%') OR (ra.EffectiveTo like '%'+@year+'%'))	
				 ORDER BY ra.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
 SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[RiskAssessment] ra 
 
 where [IsDeleted] = 0
 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (ra.AssessmentCode like '%'+@searchTerm+'%'))
 AND ((@year IS NULL OR @year = '') OR (ra.EffectiveFrom like '%'+@year+'%') OR (ra.EffectiveTo like '%'+@year+'%'))
    END");
			migrationBuilder.Sql(@"CREATE OR  ALTER     PROCEDURE [dbo].[GetTestStepListProcedure]
				 @pageSize int,
				 @pageNumber int,
				 @searchTerm nvarchar(100)
					AS
					BEGIN
						   SELECT
								 TestStep.[Id]
								,Questionnaire.Question AS Questionnaire
								,TopicHead.Name AS TopicHead
								,Country.Name AS Country
								,TestStep.TestStepDetails
								,TestStep.EffectiveFrom
								,TestStep.EffectiveTo
								
						 FROM [BranchAudit].[TestStep]
							 INNER JOIN BranchAudit.Questionnaire on TestStep.QuestionnaireId = Questionnaire.Id
							 INNER JOIN BranchAudit.TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							 INNER JOIN common.Country on Country.Id = TopicHead.CountryId
							 WHERE TestStep.IsDeleted = 0

							 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%') OR (TestStep.TestStepDetails like '%'+@searchTerm+'%'))	
							 ORDER BY TestStep.[CreatedOn] DESC
							 OFFSET((@pageNumber - 1) * @pageSize) ROWS
							 FETCH NEXT @pageSize ROWS ONLY;

					 SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[TestStep]
              INNER JOIN BranchAudit.Questionnaire on TestStep.QuestionnaireId = Questionnaire.Id
							INNER JOIN BranchAudit.TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							INNER JOIN common.Country on Country.Id = TopicHead.CountryId
							WHERE TestStep.IsDeleted = 0
							AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%') OR (TestStep.TestStepDetails like '%'+@searchTerm+'%'))	
					END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP PROCEDURE [GetUserByIdProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetDesignationListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetCountryListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetRiskProfileListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetModulewiseRolePriviliegeByRoleIdListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetModulewiseRolePriviliegeListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetRiskCriteriaListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetTopicHeadListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetEmailConfigListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetEmailTypeListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetUserListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetAuditListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetAuditFrequencyListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetRoleListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetQuestionnaireListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetWeightScoreProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetAuditPlanCodeListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetRiskAssessmentListProcedure]");
			migrationBuilder.Sql(@"DROP PROCEDURE [GetTestStepListProcedure]");

		}
    }
}
