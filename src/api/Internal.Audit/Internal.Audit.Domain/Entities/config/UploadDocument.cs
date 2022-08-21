using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.config;

[Table("UploadDocument", Schema = "Config")]
public class UploadDocument:EntityBase
{
    public string DocumentVersion { get; set; }
    public Guid  DocumentId { get; set; }
    public string Description { get; set; }
    public string ApprovedBy { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public string UploadedBy { get; set; }
    public virtual  List<UploadedDocumentsNotify> UploadedDocumentsNotify { get; set; }
    [NotMapped]
    public virtual  Document Document { get; set; }
    [NotMapped]
    public string NotifyList { get; set; }
    [NotMapped]
    public virtual EfTotalCount TotalCount { get; set; }


}
