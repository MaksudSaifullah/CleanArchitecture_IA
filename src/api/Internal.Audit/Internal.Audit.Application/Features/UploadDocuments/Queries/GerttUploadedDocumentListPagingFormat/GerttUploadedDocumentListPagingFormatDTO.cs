using Internal.Audit.Application.Features.UploadDocuments.Queries.GetUploadedDocumentListByRoled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UploadDocuments.Queries.GerttUploadedDocumentListPagingFormat;

public class GerttUploadedDocumentListPagingFormatDTO
{
    public IList<GetUploadedDocumentLstByRoleIdDTO> Items { get; set; }
    public long TotalCount { get; set; }
}
