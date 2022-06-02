using MediatR;

namespace Internal.Audit.Application.Features.Roles.Commands.AddRole;

public class AddRoleCommand: IRequest<AddRoleResponseDTO>
{ 
        public string Name { get; set; }
        public string Description { get; set; }
}

