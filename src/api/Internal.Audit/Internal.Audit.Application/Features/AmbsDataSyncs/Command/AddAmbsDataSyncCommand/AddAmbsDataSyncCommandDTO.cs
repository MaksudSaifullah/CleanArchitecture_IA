using Internal.Audit.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Command.AddAmbsDataSyncCommand;

public record AddAmbsDataSyncCommandDTO : BaseResponseDTO
{
    public AddAmbsDataSyncCommandDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
