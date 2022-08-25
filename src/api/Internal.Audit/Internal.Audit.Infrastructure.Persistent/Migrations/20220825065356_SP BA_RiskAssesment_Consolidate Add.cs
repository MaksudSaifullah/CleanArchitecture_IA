using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class SPBA_RiskAssesment_ConsolidateAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE BA_RiskAssesment_Consolidate
	@countryid uniqueidentifier,
	@riskassesmentid uniqueidentifier
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select * into #t1  FROM(SELECT   branch.BranchId,branch.BranchName,c.text,z.Value,z.Score,z.Rating
FROM [InternalAuditDb].[BranchAudit].[RiskAssesmentDataManagementLog] x
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

select cast(@riskassesmentid as uniqueidentifier)RiskAssesmentId,* from(
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
