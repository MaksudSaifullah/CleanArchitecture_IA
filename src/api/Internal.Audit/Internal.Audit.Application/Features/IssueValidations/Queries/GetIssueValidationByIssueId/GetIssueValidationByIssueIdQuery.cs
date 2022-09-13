using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.IssueValidations.Queries.GetIssueValidationByIssueId;

public record GetIssueValidationByIssueIdQuery(Guid IssueId):IRequest<IEnumerable<GetIssueValidationByIssueIdQueryResponseDTO>>;

