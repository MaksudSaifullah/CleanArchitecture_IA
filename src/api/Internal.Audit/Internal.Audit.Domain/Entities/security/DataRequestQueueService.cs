using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security;
[Table("DataRequestQueueService", Schema = "Security")]
public class DataRequestQueueService:EntityBase
{
    [Required]
    public Guid CountryId { get; set; }
    [Required]
    [MaxLength(10)]
    public string RequestType { get; set; }
    [Required]
    public DateTime FromDate { get; set; }
    [Required]
    public DateTime ToDate { get; set; }
    public DateTime RequestedOn { get; set; }
    public int Status { get; set; }
    [Required]
    [DefaultValue("1")]
    public bool IsActive{ get; set; }
    public virtual Country Country { get; set; }

}
