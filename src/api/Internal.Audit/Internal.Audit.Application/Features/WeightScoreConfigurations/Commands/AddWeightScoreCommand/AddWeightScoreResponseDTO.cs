using Internal.Audit.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WeightScoreConfigurations.Commands.AddWeightScoreCommand;

public record AddWeightScoreResponseDTO : BaseResponseDTO
{
    public AddWeightScoreResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
