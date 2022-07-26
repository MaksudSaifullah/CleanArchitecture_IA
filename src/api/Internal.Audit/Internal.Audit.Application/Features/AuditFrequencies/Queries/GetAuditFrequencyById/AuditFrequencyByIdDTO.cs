using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Queries.GetAuditFrequencyById;
public record AuditFrequencyByIdDTO

{
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid AuditScoreId { get; set; }
        public Guid RatingTypeId { get; set; }
        public Guid AuditFrequencyTypeId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTo { get; set; }
    
}
