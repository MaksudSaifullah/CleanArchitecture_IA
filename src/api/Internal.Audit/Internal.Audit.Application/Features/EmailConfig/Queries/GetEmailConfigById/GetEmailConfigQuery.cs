using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.EmailConfig.Queries.GetEmailConfigById;
public record GetEmailConfigQuery(Guid Id) : IRequest<GetEmailConfigByIdResponseDTO>;
