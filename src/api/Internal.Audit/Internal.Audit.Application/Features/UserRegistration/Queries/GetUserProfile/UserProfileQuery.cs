using MediatR;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetUserProfile
{
    public class UserProfileQuery : IRequest<UserProfileQueryResponseDTO>
    {
    }
}
