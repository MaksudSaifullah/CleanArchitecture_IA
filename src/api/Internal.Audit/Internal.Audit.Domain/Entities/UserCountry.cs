using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities
{
    [Table("UserCountry", Schema = "security")]
    public class UserCountry: EntityBase
    {
        [Required]
       
        public Guid CountryId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [DefaultValue("1")]
        public bool IsActive { get; set; }

        //Navigation properties
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; } = null!;

        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;



    }
}
