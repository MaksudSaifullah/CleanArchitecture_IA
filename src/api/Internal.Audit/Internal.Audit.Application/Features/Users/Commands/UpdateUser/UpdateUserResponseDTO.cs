﻿
using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Users.Commands.UpdateUser;

public record UpdateUserResponseDTO : BaseResponseDTO
{
    public UpdateUserResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
