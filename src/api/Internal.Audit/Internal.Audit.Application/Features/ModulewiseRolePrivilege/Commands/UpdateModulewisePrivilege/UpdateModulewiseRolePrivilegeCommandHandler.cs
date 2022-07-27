using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Commands.UpdateModulewisePrivilege
{
    public class UpdateModulewiseRolePrivilegeCommandHandler : IRequestHandler<UpdateModulewiseRolePrivilegeCommand, UpdateModulewiseRolePrivilegeResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModulewiseRolePrivilegeCommandRepository _modulewiseRoleCommandRepository;
        private readonly IMapper _mapper;

        public UpdateModulewiseRolePrivilegeCommandHandler(IUnitOfWork unitOfWork, IModulewiseRolePrivilegeCommandRepository modulewiseRoleCommandRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _modulewiseRoleCommandRepository = modulewiseRoleCommandRepository ?? throw new ArgumentNullException(nameof(modulewiseRoleCommandRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<UpdateModulewiseRolePrivilegeResponseDTO> Handle(UpdateModulewiseRolePrivilegeCommand request, CancellationToken cancellationToken)
        {
            var modulewiseRole = await _modulewiseRoleCommandRepository.Get(request.Id);
            modulewiseRole = _mapper.Map(request, modulewiseRole);
            await _modulewiseRoleCommandRepository.Update(modulewiseRole);
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new UpdateModulewiseRolePrivilegeResponseDTO(modulewiseRole.Id, rowsAffected > 0, rowsAffected > 0 ? "Module wise role Updated Successfully!" : "Error while updating Module wise role!");
        }
    }
}
