using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.DocumentSources.Queries.GetAllDocumentSource;

public record GetAllDocumentSourceQuery:IRequest<IEnumerable<GetAllDocumentSourceDTO>>;

