using Internal.Audit.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities.security
{
    [Table("UserPasswordReset",Schema = "security")]
    public class UserPasswordReset : EntityBase
    {
        [Required]
        public Guid UserId { get; set; }
        public string PasswordResetUrlCode { get; set; } = null!;
        public DateTime PasswordResetUrlCodeExpiry { get; set; }
        public string? PasswordResetPostCode { get; set; }
        public DateTime? PasswordResetPostCodeExpiry { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedOn { get; set; }
    }
}
