using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Designation.Commands.AddDesignation;

public class AddDesignationCommand : IRequest<AddDesignationResponseDTO>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}
