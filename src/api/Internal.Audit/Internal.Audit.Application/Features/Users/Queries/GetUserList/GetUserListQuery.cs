
using MediatR;

namespace Internal.Audit.Application.Features.Users.Queries.GetUserList;

public class GetUserListQuery: IRequest<List<UserDTO>>
{
    public bool OnlyActive { get; set; }

    public GetUserListQuery(bool onlyActive)
    {
        OnlyActive = onlyActive;
    }
}
