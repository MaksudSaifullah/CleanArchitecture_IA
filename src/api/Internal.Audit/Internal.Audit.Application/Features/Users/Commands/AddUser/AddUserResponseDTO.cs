﻿
using Internal.Audit.Application.Common;

namespace Internal.Audit.Application.Features.Users.Commands.AddUser;

public record AddUserResponseDTO : BaseResponseDTO
{
    public AddUserResponseDTO(Guid Id, bool Success, string Message) : base(Id, Success, Message)
    {
    }
}
