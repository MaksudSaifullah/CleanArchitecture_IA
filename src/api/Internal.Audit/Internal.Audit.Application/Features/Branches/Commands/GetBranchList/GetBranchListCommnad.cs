using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Branches.Commands.GetBranchList;

public record GetBranchListCommnad(Guid? countyrId,int pageNumber,int pageSize):IRequest<GetBranchListResponseDTO>;

