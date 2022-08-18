using MediatR;

namespace Internal.Audit.Application.Features.UploadDocuments.Commands.AddUploadDocument;

public class AddUploadDocumentCommand:IRequest<AddUploadDocumentResponseDTO>
{
    public string DocumentVersion { get; set; }
    public Guid DocumentId { get; set; }
    public string Description { get; set; }
    public string ApprovedBy { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveTo { get; set; }
    public string UploadedBy { get; set; }
    public virtual ICollection<UploadedDocumentsNotifyCommand> UploadedDocumentsNotify { get; set; }
}

public class UploadedDocumentsNotifyCommand
{ 
    public Guid RoleId { get; set; }
    public bool IsMailSent { get; set; } = false;  

}