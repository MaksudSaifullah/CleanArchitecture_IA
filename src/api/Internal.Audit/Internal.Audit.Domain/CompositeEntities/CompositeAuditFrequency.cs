using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities;
public class CompositeAuditFrequency : EntityBase

{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }

    public Guid AuditScoreId { get; set; }
    public string AuditScore { get; set; } = null!;
    public Guid RatingTypeId { get; set; }
    public string RatingType { get; set; } = null!;
    public Guid AuditFrequencyTypeId { get; set; }
    public string AuditFrequencyType { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public String CountryName { get; set; }
}
