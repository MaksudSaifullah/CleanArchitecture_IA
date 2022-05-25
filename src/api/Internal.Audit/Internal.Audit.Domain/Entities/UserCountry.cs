using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities
{
    internal class UserCountry
    {
        [Required]
       
        public Guid CountryId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string IsActive { get; set; } = null!;

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }



    }
}
