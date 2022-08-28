using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UploadDocuments.Queries.GerttUploadedDocumentListPagingFormat;

public class GetUploadDocumentListPagingFormatQuery : IRequest<GerttUploadedDocumentListPagingFormatDTO>
{
    //(x RoleId, int pageNumber, int pageSize)
    public int pageSize { get; set; }
    public int pageNumber { get; set; }
    public UploadDocumentSearch searchTerm { get; set; }
}
public class UploadDocumentSearch
{
    public Guid RoleId { get; set; }
  
}