using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Common;


[Table("Country", Schema = "Common")]
public class Country : EntityBase
{
    [Required]
    [MaxLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(10)]
    public string Code { get; set; } = null!;

    //Navigation properties
    public virtual ICollection<UserCountry> UserCountries { get; set; } = null!;


}
