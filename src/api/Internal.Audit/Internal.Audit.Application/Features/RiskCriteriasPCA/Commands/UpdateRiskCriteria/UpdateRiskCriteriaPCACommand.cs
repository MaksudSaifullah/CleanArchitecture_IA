using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.UpdateRiskCriteria;
public class UpdateRiskCriteriaPCACommand : IRequest<UpdateRiskCriteriaPCAResponseDTO>

{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public string? Description { get; set; } = null;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    
}
