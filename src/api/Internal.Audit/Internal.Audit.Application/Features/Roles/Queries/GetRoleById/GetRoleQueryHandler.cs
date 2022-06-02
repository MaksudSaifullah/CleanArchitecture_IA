
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Roles.Queries.GetRoleById;
public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery ,RoleByIdDTO >
{
    private readonly IRoleQueryRepository _roleRepository;
    private readonly IMapper _mapper;

    public GetRoleQueryHandler(IRoleQueryRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RoleByIdDTO> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var country = await _roleRepository.GetById(request.Id);
        return _mapper.Map<RoleByIdDTO>(country);
    }
}
