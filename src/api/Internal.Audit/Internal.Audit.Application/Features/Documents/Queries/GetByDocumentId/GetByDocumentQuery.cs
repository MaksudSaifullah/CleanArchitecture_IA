using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Documents.Queries.GetByDocumentId;

public record GetByDocumentQuery(Guid id):IRequest<GetByDocumentIdResponseDTO>;

