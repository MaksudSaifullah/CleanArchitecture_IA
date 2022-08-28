using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.TopicHeads.Queries.GetTopicHeadByCountryIdAndDateRange;

public record TopicHeadByCountryIdAndDateRangeQuery(Guid? countryId, DateTime? FromDate,DateTime?Todate):IRequest<IEnumerable<TopicHeadByCountryIdAndDateRangeDTO>>;

