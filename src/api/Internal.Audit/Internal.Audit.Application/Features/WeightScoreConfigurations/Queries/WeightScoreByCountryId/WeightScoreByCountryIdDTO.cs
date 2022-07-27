using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WeightScoreConfigurations.Queries.WeightScoreByCountryId;
public record WeightScoreByCountryIdDTO
{   
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid TopicHeadId { get; set; } 
    public decimal Score { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}