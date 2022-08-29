using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class SPAMBSdatasyncListSpupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER         PROCEDURE [dbo].[GetAmbsDataSyncListRiskassesment]




@typeId int,
@conversionRate  decimal(18,2),
@FromDate datetime,
@ToDate datetime,
@CountryId nvarchar(max),
@RiskAssesmentId nvarchar(max),
@pageNumber int,
@pageSize int
AS
BEGIN




declare @totalcount bigint    
DECLARE @RiskAssesmentDataManagementLogid nvarchar(max)
DECLARE @datarequestServiceId UNIQUEIDENTIFIER
DECLARE @co nvarchar(max)
DECLARE @fromdateTable datetime









if(@typeId <=3)
begin


declare @fdate DATETIME
declare @edate DATETIME
declare @conversionRateSaved decimal(18,2)


select top 1 @RiskAssesmentDataManagementLogid=Id,@datarequestServiceId=DataRequestQueueServiceId,@conversionRateSaved=ConversionRate from [BranchAudit].[RiskAssesmentDataManagementLog]
--where TypeId=@typeId
where RiskAssessmentId=@RiskAssesmentId
and TypeId=@typeId
select top 1 @fromdateTable=FromDate,@fdate=FromDate,@edate=ToDate from security.DataRequestQueueService where Id=@datarequestServiceId


if(@RiskAssesmentDataManagementLogid is not NULL)
BEGIN




--select 'hi'
SELECT  @totalcount=count(*)
from 
security.Branch b
where b.CountryId=@CountryId






select x.DataRequestQueueServiceId as DataRequestQueueSErviceId,
x.BranchCode,
x.BranchId,
x.BranchName,
convert(decimal(30,2),isnull(y.Amount,x.Amount))Amount,
convert(decimal(30,2),isnull(y.AmountConverted,x.AmountConverted))AmountConverted,
isnull(y.Score,x.Score)Score,
isnull(y.Text,x.Text)Text,
isnull(y.IsDraft,x.IsDraft)IsDraft,
x.CountryId as CountryId,
x.TC FROM(select @datarequestServiceId as [DataRequestQueueServiceId],b.BranchCode,b.BranchId,b.BranchName,0 as Amount, 0 as AmountConverted,z.Score as Score,p.Text as Text,cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,
1  as isDraft,@totalcount as TC
from 
security.Branch b
inner join [BranchAudit].[RiskCriteria] z
on z.CountryId=@CountryId 
inner JOIN [Config].[CommonValueAndType] p
on p.Id=z.RatingTypeId
inner JOIN [Config].[CommonValueAndType] q
on q.Id=z.RiskCriteriaTypeId
WHERE CAST(@fdate as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
and CAST(@edate as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
AND 0 BETWEEN z.MinimumValue and z.MaximumValue
and b.CountryId=@CountryId
)x

left join (

select @datarequestServiceId as [DataRequestQueueServiceId],b.BranchCode,b.BranchId,b.BranchName,x.Value as Amount,(x.Value*@conversionRateSaved) as AmountConverted,x.Score,x.Rating as Text,
cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,x.IsDraft,@totalcount TC from [BranchAudit].[RiskAssesmentDataManagement] x
inner join security.Branch b
on b.BranchId=x.BranchId
where RiskAssesmentDataManagementLogId=@RiskAssesmentDataManagementLogid
and b.CountryId=@CountryId

)y
on x.BranchId=y.BranchId
order by x.BranchId
OFFSET case when  @pageSize=-1 then 0 else ((@pageNumber-1) * @pageSize) end ROWS
FETCH NEXT case when @pageSize=-1 THEN case when @totalcount=0 then 1 else @totalcount end  else @pageSize end  ROWS ONLY;





END
ELSE

BEGIN

declare @fdate1 DATETIME
declare @edate1 DATETIME
--select 'hi'
SELECT  @totalcount=count(*)
from 
security.Branch b
where b.CountryId=@CountryId

SELECT @datarequestServiceId=y.Id,@fdate1=y.FromDate,@edate1=y.ToDate
  FROM [InternalAuditDb].[BranchAudit].[RiskAssessment] x 
  INNER JOIN security.DataRequestQueueService y
  on cast(x.EffectiveFrom as DATE)=cast(y.FromDate as DATE) and cast(x.EffectiveTo as DATE)=cast(y.ToDate as DATE)
  where x.id=@RiskAssesmentId
  and y.Status=3


--select @datarequestServiceId as DataRequestQueueSErviceId,b.BranchCode,b.BranchId,b.BranchName,0 as Amount, 0 as AmountConverted,z.Score as Score,p.Text as Text,cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,
--1  as isDraft,@totalcount as TC
--from 
--security.Branch b
--inner join [BranchAudit].[RiskCriteria] z
--on z.CountryId=@CountryId 
--inner JOIN [Config].[CommonValueAndType] p
--on p.Id=z.RatingTypeId
--inner JOIN [Config].[CommonValueAndType] q
--on q.Id=z.RiskCriteriaTypeId
--WHERE CAST(@fdate1 as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
--and CAST(@edate1 as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
--AND 0 BETWEEN z.MinimumValue and z.MaximumValue
--and b.CountryId=@CountryId
--order by b.BranchId




select x.DataRequestQueueSErviceId,x.BranchCode,x.BranchId,x.BranchName,
isnull(y.Amount,x.Amount)Amount,
isnull(y.AmountConverted,x.AmountConverted)AmountConverted,
isnull(y.Score,x.Score)Score,
isnull(y.Text,x.Text)Text,
cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,
1 as isDraft,
@totalcount as TC




from(select @datarequestServiceId as DataRequestQueueSErviceId,b.BranchCode,b.BranchId,b.BranchName,0 as Amount, 0 as AmountConverted,z.Score as Score,p.Text as Text,p.Id as PID,cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,
1  as isDraft,@totalcount as TC
from 
security.Branch b
inner join [BranchAudit].[RiskCriteria] z
on z.CountryId=@CountryId 
inner JOIN [Config].[CommonValueAndType] p
on p.Id=z.RatingTypeId
inner JOIN [Config].[CommonValueAndType] q
on q.Id=z.RiskCriteriaTypeId
WHERE CAST(@fdate1 as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
and CAST(@edate1 as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
AND 0 BETWEEN z.MinimumValue and z.MaximumValue
and b.CountryId=@CountryId
)x
left join(

select @datarequestServiceId as DataRequestQueueSErviceId,x.BranchCode, x.BranchId,x.BranchName,x.Amount,convert(decimal(30,2),x.Amount*@conversionrate)AmountConverted,z.Score,p.Text,p.Id as PID,@CountryId as CountryId,1 as isDrfat,@totalcount as TC
from security.AmbsDataSync x
inner join [BranchAudit].[RiskCriteria] z
on z.CountryId=@CountryId
inner JOIN [Config].[CommonValueAndType] p
on p.Id=z.RatingTypeId
inner JOIN [Config].[CommonValueAndType] q
on q.Id=z.RiskCriteriaTypeId
where x.DataRequestQueueServiceId=@datarequestServiceId
and x.CommonValueTableId=@typeId
and CAST(@fdate1 as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
and CAST(@edate1 as DATE) BETWEEN CAST(z.EffectiveFrom as DATE) and  CAST(z.EffectiveTo as DATE)
AND convert(decimal(30,2),x.Amount*@conversionrate) BETWEEN z.MinimumValue and z.MaximumValue
--order by BranchId
)y
on x.branchid=y.branchid
order by x.BranchId
OFFSET case when  @pageSize=-1 then 0 else ((@pageNumber-1) * @pageSize) end ROWS
FETCH NEXT case when @pageSize=-1 THEN case when @totalcount=0 then 1 else @totalcount end  else @pageSize end  ROWS ONLY;

end




end

else 

BEGIN

SELECT  @totalcount=count(*)
from 
security.Branch b
where b.CountryId=@CountryId


select top 1 @RiskAssesmentDataManagementLogid=Id,@datarequestServiceId=DataRequestQueueServiceId from [BranchAudit].[RiskAssesmentDataManagementLog]
where TypeId=@typeId
and RiskAssessmentId=@RiskAssesmentId


if(@RiskAssesmentDataManagementLogid is null)
BEGIN

SELECT @datarequestServiceId=y.Id
  FROM [InternalAuditDb].[BranchAudit].[RiskAssessment] x 
  INNER JOIN security.DataRequestQueueService y
  on cast(x.EffectiveFrom as DATE)=cast(y.FromDate as DATE) and cast(x.EffectiveTo as DATE)=cast(y.ToDate as DATE)
  where x.id=@RiskAssesmentId
  and y.Status=3
--select top 1 @RiskAssesmentDataManagementLogid=Id,@datarequestServiceId=DataRequestQueueServiceId from [BranchAudit].[RiskAssesmentDataManagementLog]
--where  RiskAssessmentId=@RiskAssesmentId

select @datarequestServiceId as DataRequestQueueSErviceId,b.BranchCode,b.BranchId,b.BranchName,-1 as Amount, -1 as AmountConverted,-1 as Score,'SELECT' as Text,cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,1  as isDraft,@totalcount as TC from 
security.Branch b
where b.CountryId=@CountryId
order by BranchId
OFFSET case when  @pageSize=-1 then 0 else ((@pageNumber-1) * @pageSize) end ROWS
FETCH NEXT case when @pageSize=-1 THEN case when @totalcount=0 then 1 else @totalcount end  else @pageSize end  ROWS ONLY;


END

ELSE
begin

select  x.DataRequestQueueServiceId as DataRequestQueueSErviceId,
x.BranchCode,
x.BranchId,
x.BranchName,
convert(decimal(30,2),isnull(y.Amount,x.Amount))Amount,
convert(decimal(30,2),isnull(y.AmountConverted,x.AmountConverted))AmountConverted,
isnull(y.Score,x.Score)Score,
isnull(y.Text,x.Text)Text,
isnull(y.IsDraft,x.IsDraft)IsDraft,
x.CountryId as CountryId,
x.TC from(select @datarequestServiceId as [DataRequestQueueServiceId],b.BranchCode,b.BranchId,b.BranchName,-1 as Amount, -1 as AmountConverted,-1 as Score,'SELECT' as Text,cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,1  as isDraft,@totalcount as TC from 
security.Branch b
where b.CountryId=@CountryId
)x
left join (
select @datarequestServiceId as [DataRequestQueueServiceId],b.BranchCode,b.BranchId,b.BranchName,x.Value as Amount,x.Value as AmountConverted,x.Score,x.Rating as Text,
cast(@CountryId as UNIQUEIDENTIFIER) as CountryId,x.IsDraft,@totalcount TC from [BranchAudit].[RiskAssesmentDataManagement] x
inner join security.Branch b
on b.BranchId=x.BranchId
where RiskAssesmentDataManagementLogId=@RiskAssesmentDataManagementLogid
and b.CountryId=@CountryId
)y
on x.BranchId=y.BranchId
order by x.BranchId
OFFSET case when  @pageSize=-1 then 0 else ((@pageNumber-1) * @pageSize) end ROWS
FETCH NEXT case when @pageSize=-1 THEN case when @totalcount=0 then 1 else @totalcount end  else @pageSize end  ROWS ONLY;
END

END

end");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE GetAmbsDataSyncListRiskassesment");
        }
    }
}
