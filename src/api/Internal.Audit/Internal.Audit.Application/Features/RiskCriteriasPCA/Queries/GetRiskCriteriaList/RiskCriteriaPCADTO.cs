using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaList;
public record RiskCriteriaPCADTO
{
    //public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;
    public string? CountryName { get; set; }


}


