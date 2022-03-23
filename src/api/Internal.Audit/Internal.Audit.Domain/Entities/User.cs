
using Internal.Audit.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Internal.Audit.Domain.Entities;

public class User: EntityBase
{
    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = null!;
    [Required]
    [MaxLength(15)]
    public string Password { get; set; } = null!;
    public bool Status { get; set; }
    public bool LoginStatus { get; set; }
    public DateTime? LastLoginTime { get; set; }
}
