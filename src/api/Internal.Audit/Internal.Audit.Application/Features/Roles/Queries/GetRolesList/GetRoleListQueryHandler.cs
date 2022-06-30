using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Roles;
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
            var (count, result) = await _roleRepository.GetAll(request.pageSize, request.pageNumber);

            var countryList = _mapper.Map<IEnumerable<RoleDTO>>(result).ToList();

            return new RoleListPagingDTO { Items = countryList, TotalCount = count };

        }
    }
}



