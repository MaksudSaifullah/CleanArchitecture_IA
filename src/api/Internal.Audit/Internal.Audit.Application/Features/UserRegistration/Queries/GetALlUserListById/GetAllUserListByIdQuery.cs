using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UserRegistration.Queries.GetALlUserListById
{
    public record GetAllUserListByIdQuery(Guid userId):IRequest<GetALlUserListByIdResponseDTO>;
   
}
