using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class AmbsdatasyncdataStoredprocedureGetAmbsDataSyncList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE or ALTER PROCEDURE [dbo].[GetAmbsDataSyncList]


@typeId int,
@conversionRate  decimal(18,2),
@FromDate datetime,
@ToDate datetime,
@CountryId nvarchar(max),
@pageNumber int,
@pageSize int
AS
BEGIN



declare @totalcount bigint	

SELECT  @totalcount=count(*)
FROM [security].[AmbsDataSync] x
inner join [security].[DataRequestQueueService] y
on x.DataRequestQueueServiceId=y.Id
inner join [common].[Country] c
on c.Id=y.CountryId
inner join [BranchAudit].[RiskCriteria] z
on z.CountryId=y.CountryId
inner JOIN [Config].[CommonValueAndType] p
on p.Id=z.RatingTypeId
inner JOIN [Config].[CommonValueAndType] q
on q.Id=z.RiskCriteriaTypeId
where CommonValueTableId=@typeId
and CAST(x.FromDate as DATE)=CAST(@FromDate as date)
and CAST(x.ToDate as DATE)=CAST(@ToDate as date)
and CAST(@FromDate as date)>=CAST(z.EffectiveFrom as DATE)
and CAST(@ToDate as date)<=CAST(z.EffectiveTo as DATE)
and x.[Amount] BETWEEN z.MinimumValue and z.MaximumValue
and x.IsDeleted=0
and y.CountryId=@CountryId
SELECT  x.[Id]
,x.[DataRequestQueueServiceId]
,x.[BranchCode]
,x.[BranchId]
,x.[BranchName]
,x.[Amount]
,x.[Amount]* @conversionRate as AmountConverted 
,x.[IsActive]
,x.[FromDate]
,x.[ToDate]
,x.[CommonValueTableId]
,x.[CreatedBy]
,x.[CreatedOn]
,x.[UpdatedBy]
,x.[UpdatedOn]
,x.[ReviewedBy]
,x.[ReviewedOn]
,x.[ApprovedBy]
,x.[ApprovedOn]
,x.[IsDeleted],y.*,c.*,z.*,p.*,q.*,@totalcount as TC
FROM [security].[AmbsDataSync] x
inner join [security].[DataRequestQueueService] y
on x.DataRequestQueueServiceId=y.Id
inner join [common].[Country] c
on c.Id=y.CountryId
inner join [BranchAudit].[RiskCriteria] z
on z.CountryId=y.CountryId
inner JOIN [Config].[CommonValueAndType] p
on p.Id=z.RatingTypeId
inner JOIN [Config].[CommonValueAndType] q
on q.Id=z.RiskCriteriaTypeId
where CommonValueTableId=@typeId
and CAST(x.FromDate as DATE)=CAST(@FromDate as date)
and CAST(x.ToDate as DATE)=CAST(@ToDate as date)
and CAST(@FromDate as date)>=CAST(z.EffectiveFrom as DATE)
and CAST(@ToDate as date)<=CAST(z.EffectiveTo as DATE)
and x.[Amount] BETWEEN z.MinimumValue and z.MaximumValue
and x.IsDeleted=0
and y.CountryId=@CountryId
order by x.FromDate
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

end");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [GetAmbsDataSyncList]");
        }
    }
}
