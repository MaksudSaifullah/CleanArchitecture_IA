using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UploadDocuments.Queries.GetUploadedDocumentListByRoled;

public record GetUploadedDocumentListByRoleIdQuery(Guid RoleId, int pageNumber, int pageSize) :IRequest<IEnumerable<GetUploadedDocumentLstByRoleIdDTO>>;
