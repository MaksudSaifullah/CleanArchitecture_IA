using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Queries.GetRiskAssesmentData;

public class GetRiskAssesmentDataQueryDTO
{
    public Guid DataRequestQueueSErviceId { get; set; }
    public long BranchCode { get; set; }
    public long BranchId { get; set; }
    public string BranchName { get; set; }
    public decimal Amount { get; set; }
    public decimal AmountConverted { get; set; }
    public float Score { get; set; }
    public string Text { get; set; }
    public Guid CountryId { get; set; }
    public bool IsDraft { get; set; }
    public virtual EfTotalCount TotalCount { get; set; }
}
