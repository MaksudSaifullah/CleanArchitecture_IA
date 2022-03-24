
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Queries.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<UserDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.Get(request.OnlyActive);
        return _mapper.Map<List<UserDTO>>(users);
    }
}
