using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using MediatR;

namespace Internal.Audit.Application.Features.Roles.Queries.GetRolesList
{
    public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, List<RoleDTO>>
    {
        private readonly IRoleQueryRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleListQueryHandler(IRoleQueryRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<RoleDTO>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAll();
            return _mapper.Map<List<RoleDTO>>(roles);

        }
    }
}



