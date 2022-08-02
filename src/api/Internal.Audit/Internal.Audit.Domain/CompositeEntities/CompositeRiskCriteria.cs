using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities;
public class CompositeRiskCriteria : EntityBase

{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }

    public Guid RiskCriteriaTypeId { get; set; }
    public string RiskCriteriaType { get; set; } = null!;
    public decimal MinimumValue { get; set; }
    public decimal MaximumValue { get; set; }
    public Guid RatingTypeId { get; set; }
    public string RatingType { get; set; } = null!;
    public decimal Score { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string Description { get; set; } = null!;
    public String CountryName { get; set; }
}
