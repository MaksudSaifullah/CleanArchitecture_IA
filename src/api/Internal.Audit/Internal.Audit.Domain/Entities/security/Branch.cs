using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security;
[Table("Branch", Schema = "Security")]
public class Branch : EntityBase
{
    [Required]
    public Guid CountryId { get; set; }
    public int BranchCode { get; set; }
    public long BranchId { get; set; }
    [Required]
    [MaxLength(20)]
    public string? BranchName { get; set; }
    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;
}
