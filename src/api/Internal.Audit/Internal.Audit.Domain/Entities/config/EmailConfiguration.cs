using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.config;
[Table("EmailConfiguration", Schema = "Config")]
public class EmailConfiguration: EntityBase
{
    [Required]
    public Guid EmailTypeId { get; set; }
    [Required]
    public Guid CountryId { get; set; }
    [Required]
    public string TemplateSubject { get; set; }
    [Required]
    public string TemplateBody { get; set; }

    [ForeignKey("EmailTypeId")]
    public virtual EmailType EmailType { get; set; } = null!;
    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; } = null!;

}
