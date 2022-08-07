using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Config;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security;
[Table("AmbsDataSync", Schema = "Security")]
public class AmbsDataSync : EntityBase
{
    public Guid DataRequestQueueServiceId { get; set; }
    public int BranchCode { get; set; }
    public long BranchId { get; set; }
    [Required]
    [MaxLength(50)]
    public string? BranchName { get; set; }
    public decimal Amount { get; set; }
    public decimal? AmountConverted { get; set; }
    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    //public Guid CommonValueAndTypeId { get; set; }
    public int CommonValueTableId { get; set; }
    //public Guid CountryId { get; set; }
    //[ForeignKey("CountryId")]
    //public virtual Country Country { get; set; } = null!;

    //[ForeignKey("CommonValueAndTypeId")]
    //public virtual CommonValueAndType CommonValueAndType { get; set; } = null!;

    [ForeignKey("DataRequestQueueServiceId")]
    public virtual DataRequestQueueService DataRequestQueueService { get; set; } = null!;
    [NotMapped]
    public virtual RiskCriteria RiskCriteria { get; set; } = null!;
    [NotMapped]
    public virtual EfTotalCount TotalCount { get; set; }

}
