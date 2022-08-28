using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class SPconsolidateupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"create OR ALTER   PROCEDURE [dbo].[BA_RiskAssesment_Consolidate]
	@countryid uniqueidentifier,
	@riskassesmentid uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


	declare @totalCount int

	select @totalCount=count(*) from 
	[BranchAudit].[RiskAssesmentDataManagementLog]

	if(@totalCount<6)
	begin
	select -1 as retval
	RETURN;

	END





	select *into #frequency from(SELECT
	    af.[Id]
		,cntr.Id AS CountryId
		,cntr.Name AS CountryName
	    ,cvtas.Text AS AuditScore
	    ,cvtrt.Text AS RatingType
		,cvtaf.Text AS AuditFrequencyType
        
        FROM[BranchAudit].[AuditFrequency] as af
	    INNER JOIN [common].[Country] as cntr on cntr.Id = af.CountryId 
	    INNER JOIN [config].[CommonValueAndType] as cvtas on cvtas.Id = af.AuditScoreId      
        INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = af.RatingTypeId
		INNER JOIN [config].[CommonValueAndType] as cvtaf on cvtaf.Id = af.AuditFrequencyTypeId
     WHERE af.[IsDeleted] = 0 and af.CountryId=@countryid

	 )x







   select * into #t1  FROM(SELECT   branch.BranchId,branch.BranchName,c.text,z.Value,z.Score,z.Rating
FROM [BranchAudit].[RiskAssesmentDataManagementLog] x
inner JOIN security.DataRequestQueueService y
on x.DataRequestQueueServiceId=y.Id
INNER JOIN BranchAudit.RiskAssesmentDataManagement z
on x.Id=z.RiskAssesmentDataManagementLogId
INNER JOIN security.Branch branch
on branch.BranchId=z.BranchId
inner JOIN Config.CommonValueAndType c
on x.TypeId=c.Value
--inner JOIN Config.CommonValueAndType cr 
--on cr.Value=
WHERE x.RiskAssessmentId=@riskassesmentid
and z.IsDraft=0
and branch.CountryId=@countryid
and c.Type='RISKRATINGNAME'

)x




select branchid,branchname,REPLACE([text],' ','') as Text,score, case
when rating='High' then 3
when rating='Medium' then 2
when rating='Low' then 1
when rating='Extreme' then 4
end
as RR
into #tr from  #t1 

--select * from #tr

select l.*,f.AuditFrequencyType as AuditFrequency_Type from(select cast(@riskassesmentid as uniqueidentifier)RiskAssesmentId,*,([Loproductivity_Score]+[Fraud_Score]+[StaffTurnOver_Score]+[Overdue_Score]+[Collection_Score]+[Disbursement_Score])/6 [Avg_Score],
CASE 
WHEN ([Loproductivity_Score]+[Fraud_Score]+[StaffTurnOver_Score]+[Overdue_Score]+[Collection_Score]+[Disbursement_Score])/6 <=1 then 'Low'
WHEN ([Loproductivity_Score]+[Fraud_Score]+[StaffTurnOver_Score]+[Overdue_Score]+[Collection_Score]+[Disbursement_Score])/6 <=2 and ([Loproductivity_Score]+[Fraud_Score]+[StaffTurnOver_Score]+[Overdue_Score]+[Collection_Score]+[Disbursement_Score])/6>1 then 'Medium'
WHEN ([Loproductivity_Score]+[Fraud_Score]+[StaffTurnOver_Score]+[Overdue_Score]+[Collection_Score]+[Disbursement_Score])/6 <=3 and ([Loproductivity_Score]+[Fraud_Score]+[StaffTurnOver_Score]+[Overdue_Score]+[Collection_Score]+[Disbursement_Score])/6>2 then 'High'
else 'Extreme'
end As Avg_Rating

from(
select branchname,branchid,
SLoproductivity as [Loproductivity_Score],
case when [RLoproductivity]=1 then 'Low' when [RLoproductivity]=2 then 'Medium' when [RLoproductivity]=3 then 'High'  when [RLoproductivity]=4 then 'Extreme' END [Loproductivity_Rating],
SFraud as [Fraud_Score],
case when [RFraud]=1 then 'Low' when [RFraud]=2 then 'Medium' when [RFraud]=3 then 'High'  when [RFraud]=4 then 'Extreme' END [Fraud_Rating],
SStaffTurnOver as [StaffTurnOver_Score],
case when [RStaffTurnOver]=1 then 'Low' when [RStaffTurnOver]=2 then 'Medium' when [RStaffTurnOver]=3 then 'High'  when [RStaffTurnOver]=4 then 'Extreme' END [StaffTurnOver_Rating],
SOverdue as [Overdue_Score],
case when [ROverdue]=1 then 'Low' when [ROverdue]=2 then 'Medium' when [ROverdue]=3 then 'High'  when [ROverdue]=4 then 'Extreme' END [Overdue_Rating],
SCollection as [Collection_Score],
case when [RCollection]=1 then 'Low' when [RCollection]=2 then 'Medium' when [RCollection]=3 then 'High'  when [RCollection]=4 then 'Extreme' END [Collection_Rating],
SDisbursement as [Disbursement_Score],
case when [RDisbursement]=1 then 'Low' when [RDisbursement]=2 then 'Medium' when [RDisbursement]=3 then 'High'  when [RDisbursement]=4 then 'Extreme' END [Disbursement_Rating]
from (
select * from(
select branchname,
branchid,
case
when col = 'Score' then 'S'
when col = 'RR' then 'R'   
end + cast(text as nvarchar(MAX)) new_col,
value
from  #tr
UNPIVOT (value FOR col IN ([Score],[RR])) unpiv) src

PIVOT
(MAX(value) FOR new_col IN ([SLoproductivity], [RLoproductivity], [SStaffTurnOver], [RStaffTurnOver], [SFraud],[RFraud], [SOverdue], [ROverdue], [SCollection],[RCollection],[SDisbursement],[RDisbursement])
) piv

)xx
)z
)l
left JOIN #frequency f
on l.Avg_Score=f.AuditScore

drop table #t1
drop table #tr
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP PROCEDURE BA_RiskAssesment_Consolidate");
        }
    }
}
