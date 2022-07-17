using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;
using Internal.Audit.Domain.Entities.security;
using MediatR;

namespace Internal.Audit.Application.Features.ModulewiseRolePrivilege.Commands.AddModulewiseRolePrivilege
{
    internal class AddModulewiseRolePrivilegeCommandHandler : IRequestHandler<AddModulewiseRolePrivilegeCommand, AddModulewiseRolePrivilegeResponseDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModulewiseRolePrivilegeCommandRepository _modulewiseRoleCommandRepository;
        private readonly IModulewiseRoleQueryRepository _modulewiseRolePrivilegeRepository;
        private readonly IMapper _mapper;

        public AddModulewiseRolePrivilegeCommandHandler(IModulewiseRoleQueryRepository modulewiseRolePrivilegeRepository, IModulewiseRolePrivilegeCommandRepository modulewiseRoleCommandRepository, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _modulewiseRoleCommandRepository = modulewiseRoleCommandRepository ?? throw new ArgumentNullException(nameof(modulewiseRoleCommandRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _modulewiseRolePrivilegeRepository = modulewiseRolePrivilegeRepository;
        }

        public async Task<AddModulewiseRolePrivilegeResponseDTO> Handle(AddModulewiseRolePrivilegeCommand request, CancellationToken cancellationToken)
        {
            //var resultWithCommand = await _modulewiseRoleCommandRepository.GetByRoleAuditFeatureId(request.RoleId, request.AuditFeatureId, request.AuditModuleId);
            var checkIfDataExists = await _modulewiseRolePrivilegeRepository.GetByRoleFeatureModuleId(request.RoleId, request.AuditFeatureId, request.AuditModuleId);
            if (checkIfDataExists != null)
            {
                var modulewiseRole = await _modulewiseRoleCommandRepository.Get(checkIfDataExists.Id);
                modulewiseRole = _mapper.Map(request, modulewiseRole);
                await _modulewiseRoleCommandRepository.Update(modulewiseRole);
                //var rowsAffected = await _unitOfWork.CommitAsync();

                //var dataToDelete = _mapper.Map<ModulewiseRolePriviliege>(checkIfDataExists);
                //await _modulewiseRoleCommandRepository.Delete(dataToDelete);
                var rowsAffected = await _unitOfWork.CommitAsync();
                return new AddModulewiseRolePrivilegeResponseDTO(checkIfDataExists.Id, rowsAffected > 0, rowsAffected > 0 ? "Module wise role Added Successfully!" : "Error while creating Module wise role!");
            }
            else
            {
                var modulewiseRolePrivilege = _mapper.Map<ModulewiseRolePriviliege>(request);
                await _modulewiseRoleCommandRepository.Add(modulewiseRolePrivilege);
                var rowsAffected = await _unitOfWork.CommitAsync();
                return new AddModulewiseRolePrivilegeResponseDTO(modulewiseRolePrivilege.Id, rowsAffected > 0, rowsAffected > 0 ? "Module wise role Added Successfully!" : "Error while creating Module wise role!");
            }
            
            //var rowsAffected = await _unitOfWork.CommitAsync();
            //return new AddModulewiseRolePrivilegeResponseDTO(modulewiseRolePrivilege.Id, rowsAffected > 0, rowsAffected > 0 ? "Module wise role Added Successfully!" : "Error while creating Module wise role!");
        }
    }
}
