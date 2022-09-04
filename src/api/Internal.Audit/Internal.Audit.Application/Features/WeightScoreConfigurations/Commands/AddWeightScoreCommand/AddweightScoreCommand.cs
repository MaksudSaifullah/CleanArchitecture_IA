using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WeightScoreConfigurations.Commands.AddWeightScoreCommand;

public class AddweightScoreCommand:IRequest<AddWeightScoreResponseDTO>
{
    public List<AddweightScoreCommandRaw> WeightScoreData { get; set; }
}
public class AddweightScoreCommandRaw
{
    public Guid CountryId { get; set; }
    public Guid TopicHeadId { get; set; }
    public decimal Score { get; set; }
}
