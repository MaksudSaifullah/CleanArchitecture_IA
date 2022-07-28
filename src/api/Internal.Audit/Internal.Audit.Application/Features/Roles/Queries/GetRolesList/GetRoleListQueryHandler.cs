using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using Internal.Audit.Domain.Entities.Security;
using MediatR;

namespace Internal.Audit.Application.Features.Roles.Queries.GetRolesList
{
    public class GetRoleListQueryHandler : IRequestHandler<GetRoleListQuery, RoleListPagingDTO>
    {
        private readonly IRoleQueryRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleListQueryHandler(IRoleQueryRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RoleListPagingDTO> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            (long, IEnumerable<Role>) role = await _roleRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);
            var roleList = _mapper.Map<List<RoleDTO>>(role.Item2);
            return new RoleListPagingDTO { Items = roleList, TotalCount = role.Item1 };

        }
    }
}



