using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Commands.AddRiskProfile;

public class AddRiskProfileCommand : IRequest<AddRiskProfileResponseDTO>
{
    public Guid LikelihoodTypeId { get; set; }
    public Guid ImpactTypeId { get; set; }
    public Guid RatingTypeId { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }
}
