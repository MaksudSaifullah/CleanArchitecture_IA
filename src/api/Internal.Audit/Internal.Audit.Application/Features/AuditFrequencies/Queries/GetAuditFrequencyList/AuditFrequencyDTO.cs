using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyList;
public record AuditFrequencyDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid AuditScoreId { get; set; }

    public string AuditScore { get; set; }
    public Guid RatingTypeId { get; set; }

    public string RatingType { get; set; }
    public Guid AuditFrequencyTypeId { get; set; }

    public string AuditFrequencyType { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }

    public string? CountryName { get; set; }
}
