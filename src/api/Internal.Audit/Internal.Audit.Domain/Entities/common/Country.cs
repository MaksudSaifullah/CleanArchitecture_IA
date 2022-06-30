using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Internal.Audit.Domain.Entities
{

    [Table("Country", Schema = "common")]
    public class Country : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        public string Code { get; set; } = null!;

        [MaxLength(200)]        
        public string Remarks { get; set; } = null!;

        //Navigation properties
        public virtual ICollection<UserCountry> UserCountries { get; set; } = null!;

    }
}
