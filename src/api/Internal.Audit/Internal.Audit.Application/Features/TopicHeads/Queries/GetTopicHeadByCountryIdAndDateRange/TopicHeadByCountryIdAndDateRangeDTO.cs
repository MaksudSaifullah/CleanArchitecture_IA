using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByCountryIdAndDateRange;

public record TopicHeadByCountryIdAndDateRangeDTO
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
    public string? Description { get; set; }
    public decimal WeightScore { get; set; }
}
