using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Questionnnaires.Queries.GetQuestionnaireById;
public record GetQuestionnaireByIdQuery(Guid Id) : IRequest<GetQuestionnaireByIdDTO>;