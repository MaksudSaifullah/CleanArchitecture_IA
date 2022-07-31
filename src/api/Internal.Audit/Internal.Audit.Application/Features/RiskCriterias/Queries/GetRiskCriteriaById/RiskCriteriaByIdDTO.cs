using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaById;
public record RiskCriteriaByIdDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid RiskCriteriaTypeId { get; set; }
    public decimal MinimumValue { get; set; }
    public decimal MaximumValue { get; set; }
    public Guid RatingTypeId { get; set; }
    public decimal Score { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;
}
