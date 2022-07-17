using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileList;
public record RiskProfileDTO
{
    public Guid Id { get; set; }
    public string LikelihoodType { get; set; }
    public string ImpactType { get; set; }
    public string RatingType { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
}