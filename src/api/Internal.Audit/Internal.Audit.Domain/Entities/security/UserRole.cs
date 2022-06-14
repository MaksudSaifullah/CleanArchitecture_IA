using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.security
{
    [Table("UserRole", Schema = "Security")]
    public class UserRole:EntityBase
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
