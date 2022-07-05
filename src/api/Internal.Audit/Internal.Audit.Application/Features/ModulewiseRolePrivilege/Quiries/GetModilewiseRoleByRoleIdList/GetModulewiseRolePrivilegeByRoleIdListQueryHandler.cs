using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Quiries.GetModilewiseRoleByRoleIdList
{
    public class GetModulewiseRolePrivilegeByRoleIdListQueryHandler : IRequestHandler<GetModulewiseRolePrivilegeByRoleIdListQuery, GetModulewiseRolePrivilegeByRoleIdListPagingDTO>
    {
        private readonly IModulewiseRoleQueryRepository _modulewiseRolePrivilegeRepository;
        private readonly IMapper _mapper;

        public GetModulewiseRolePrivilegeByRoleIdListQueryHandler(IModulewiseRoleQueryRepository modulewiseRolePrivilegeRepository, IMapper mapper)
        {
            _modulewiseRolePrivilegeRepository = modulewiseRolePrivilegeRepository;
            _mapper = mapper;
        }

        public async Task<GetModulewiseRolePrivilegeByRoleIdListPagingDTO> Handle(GetModulewiseRolePrivilegeByRoleIdListQuery request, CancellationToken cancellationToken)
        {
            var (count, result) = await _modulewiseRolePrivilegeRepository.GetAllByRoleId(request.pageSize, request.pageNumber,request.roleId);
            var modulewiseRoleList = _mapper.Map<List<GetModulewiseRolePrivilegeByRoleIdListResponseDTO>>(result);
            return new GetModulewiseRolePrivilegeByRoleIdListPagingDTO { Items = modulewiseRoleList, TotalCount = count };
        }
    }
}
