using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities;

[Table("RiskCriteriaType", Schema = "")]
public class RiskCriteriaType : EntityBase
{
    [Required]
    [DefaultValue("1")]
    public bool IsActive { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

}