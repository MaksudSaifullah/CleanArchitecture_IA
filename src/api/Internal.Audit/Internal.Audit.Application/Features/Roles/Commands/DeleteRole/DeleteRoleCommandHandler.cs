using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using MediatR;

namespace Internal.Audit.Application.Features.Roles.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleCommandRepository _roleRepository;
    private readonly IMapper _mapper;

    public DeleteRoleCommandHandler(IRoleCommandRepository roleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteRoleResponseDTO> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.Get(request.Id);
        role.IsDeleted = true;
        var mappedRole = _mapper.Map(request, role);
        await _roleRepository.Update(mappedRole);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteRoleResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Role Deleted Successfully!" : "Error while deleting Role!");
    }
}