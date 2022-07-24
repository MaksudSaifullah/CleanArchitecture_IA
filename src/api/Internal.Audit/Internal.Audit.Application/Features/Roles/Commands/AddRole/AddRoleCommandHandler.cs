using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Roles;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.Security;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Roles.Commands.AddRole;
public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, AddRoleResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleCommandRepository _roleRepository;
    private readonly IMapper _mapper;
    public AddRoleCommandHandler(IRoleCommandRepository countryRepository, IMapper mapper,
       IUnitOfWork unitOfWork)
    {
        _roleRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddRoleResponseDTO> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<Role>(request);
        role.IsActive = true;
        var newRole = await _roleRepository.Add(role);
        var rowsAffected = await _unitOfWork.CommitAsync();


        return new AddRoleResponseDTO(newRole.Id, rowsAffected > 0, rowsAffected > 0 ? "Role Added Successfully!" : "Error while creating Role!");
    }

}

