using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Roles.Queries.GetRoleById;
public record GetRoleQuery(Guid Id) : IRequest<RoleByIdDTO>;
