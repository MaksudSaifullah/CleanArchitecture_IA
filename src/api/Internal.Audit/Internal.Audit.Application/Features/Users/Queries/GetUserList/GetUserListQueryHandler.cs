
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using MediatR;

namespace Internal.Audit.Application.Features.Users.Queries.GetUserList;

public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<UserDTO>>
{
    private readonly IUnitOfWork _uniOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _uniOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<List<UserDTO>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.Get(request.OnlyActive);
        var rowsAffected = await _uniOfWork.CommitAsync();
        return _mapper.Map<List<UserDTO>>(users);
    }
}
