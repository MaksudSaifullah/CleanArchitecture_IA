using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Queries.GetRiskProfileList
{
    public class RiskProfileTest
    {
        public Guid Id { get; set; }
        public string LikelihoodTypeId { get; set; }
        public string ImpactTypeId { get; set; }
        public string RatingTypeId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
