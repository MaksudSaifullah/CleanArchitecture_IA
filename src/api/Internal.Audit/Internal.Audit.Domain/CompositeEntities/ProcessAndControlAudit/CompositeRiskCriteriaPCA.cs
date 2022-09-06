using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.ProcessAndControlAudit;
public class CompositeRiskCriteriaPCA : EntityBase

{
    //public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
    public string Description { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public String CountryName { get; set; }
}
