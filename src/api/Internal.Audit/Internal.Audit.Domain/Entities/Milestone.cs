using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities;

[Table("Milestone", Schema = "")]
public class Milestone : EntityBase
{

    [Required]
    public DateTime NotificationLetterIssuance { get; set; }
    [Required]
    public DateTime PlanningScopingStart { get; set; }

    [Required]
    public DateTime TermsofReferenceIssuance { get; set; }
    [Required]
    public DateTime OpeningMeeting { get; set; }

    [Required]
    public DateTime FieldworkStart { get; set; }
    [Required]
    public DateTime FieldworkEnd { get; set; }

    [Required]
    public DateTime ClosingMeeting { get; set; }
    [Required]
    public DateTime DraftReportIssuance { get; set; }

    [Required]
    public DateTime FinalReportIssuance { get; set; }
    [Required]
    public DateTime RCDShareHGIA { get; set; }

}