using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using Internal.Audit.Domain.Entities.common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Roles.Commands.UpdateRole;
public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleCommandRepository _roleRepository;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IRoleCommandRepository roleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateRoleResponseDTO> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.Get(request.Id);
        var mappedRole = _mapper.Map(request, role);
        var updatedRole = await _roleRepository.Update(mappedRole);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateRoleResponseDTO(updatedRole.Id, rowsAffected > 0, rowsAffected > 0 ? "Role Updated Successfully!" : "Error while updating Role!");
    }
}

