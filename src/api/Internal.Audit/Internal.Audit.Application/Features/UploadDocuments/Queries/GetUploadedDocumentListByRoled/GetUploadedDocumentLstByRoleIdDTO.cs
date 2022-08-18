using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.UploadDocuments.Queries.GetUploadedDocumentListByRoled;

public class GetUploadedDocumentLstByRoleIdDTO
{
    public string DocumentVersion { get; set; }
    public Guid DocumentId { get; set; }
    public string Description { get; set; }
    public string ApprovedBy { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public string UploadedBy { get; set; }
    public virtual ICollection<UploadedDocumentsNotifyDTO> UploadedDocumentsNotify { get; set; }   
    public virtual DocumentDTOc Document { get; set; }
    public virtual EfTotalCount TotalCount { get; set; }
}

public class UploadedDocumentsNotifyDTO
{
    public Guid RoleId { get; set; }
    public bool IsMailSent { get; set; }
    public virtual RoleDTOc UploadDocumentRoleList { get; set; } = null!;
}

public class RoleDTOc
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

}
public class DocumentDTOc
{
   
    public Guid DocumentSourceId { get; set; }   
    public string Path { get; set; } = null!;
   
    public string Name { get; set; } = null!;
  
    public string Format { get; set; } = null!;   
}
