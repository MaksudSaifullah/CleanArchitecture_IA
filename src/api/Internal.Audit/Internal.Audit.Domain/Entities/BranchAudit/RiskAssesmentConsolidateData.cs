using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit;
[Table("RiskAssesmentConsolidateData", Schema = "BranchAudit")]
public class RiskAssesmentConsolidateData : EntityBase
{
    public Guid RiskAssesmentId { get; set; }
    public string BranchName { get; set; }
    public int  BranchId { get; set; }
    public string Loproductivity_Score { get; set; }
    public string Loproductivity_Rating { get; set; }
    public string Fraud_Score { get; set; }
    public string Fraud_Rating { get; set; }
    public string StaffTurnOver_Score { get; set; }
    public string StaffTurnOver_Rating { get; set; }
    public string OverDue_Score { get; set; }
    public string OverDue_Rating { get; set; }
    public string Collection_Score { get; set; }
    public string Collection_Rating { get; set; }
    public string Disbursement_Score { get; set; }
    public string Disbursement_Rating { get; set; }
    public string Avg_Score { get; set; }
    public string Avg_Rating { get; set; }
    public string AuditFrequency_Type { get; set; }
    [NotMapped]
    public EfTotalCount TotalCount { get; set; }
}
