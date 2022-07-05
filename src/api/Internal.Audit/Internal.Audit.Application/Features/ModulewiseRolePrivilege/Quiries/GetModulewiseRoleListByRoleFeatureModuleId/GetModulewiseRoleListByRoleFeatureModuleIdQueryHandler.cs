using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Quiries.GetModulewiseRoleListByRoleFeatureModuleId
{
    public class GetModulewiseRoleListByRoleFeatureModuleIdQueryHandler : IRequestHandler<GetModulewiseRoleListByRoleFeatureModuleIdQuery, GetModulewiseRoleListByRoleFeatureModuleIdQueryResponseDTO>
    {
        private readonly IModulewiseRoleQueryRepository _modulewiseRolePrivilegeRepository;
        private readonly IMapper _mapper;

        public GetModulewiseRoleListByRoleFeatureModuleIdQueryHandler(IModulewiseRoleQueryRepository modulewiseRolePrivilegeRepository, IMapper mapper)
        {
            _modulewiseRolePrivilegeRepository = modulewiseRolePrivilegeRepository;
            _mapper = mapper;
        }

        public async Task<GetModulewiseRoleListByRoleFeatureModuleIdQueryResponseDTO> Handle(GetModulewiseRoleListByRoleFeatureModuleIdQuery request, CancellationToken cancellationToken)
        {
            var moduleAccessList = await _modulewiseRolePrivilegeRepository.GetByRoleFeatureModuleId(request.roleId,request.auditFeatureId,request.moduleId);
            return _mapper.Map<GetModulewiseRoleListByRoleFeatureModuleIdQueryResponseDTO>(moduleAccessList);
        }
    }
}
