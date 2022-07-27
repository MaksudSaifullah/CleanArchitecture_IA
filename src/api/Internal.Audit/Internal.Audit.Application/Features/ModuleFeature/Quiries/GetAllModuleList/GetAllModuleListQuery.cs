using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ModuleFeature.Quiries.GetAllModuleList;

public record GetAllModuleListQuery(Guid featureId):IRequest<IEnumerable<GetAllModuleListResponseDTO>>;

