using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Roles.Commands.DeleteRole;
public class DeleteRoleCommand : IRequest<DeleteRoleResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteRoleCommand(Guid id)
    {
        Id = id;
    }
}