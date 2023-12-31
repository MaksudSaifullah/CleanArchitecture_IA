﻿using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.BranchAudit
{
    [Table("AuditCreation", Schema = "BranchAudit")]
    public class AuditCreation : EntityBase
    {
       
        public Guid AuditTypeId { get; set; }
        //public string PlanId { get; set; }
        [Required]
        public Guid AuditPlanId { get; set; }
        [Required]
        public string AuditId { get; set; }
        [Required]
        public Int32 Year { get; set; }
        [Required]
        public string AuditName { get; set; }
        [Required]
        public DateTime AuditPeriodFrom { get; set; }
        public DateTime AuditPeriodTo { get; set; }
     
        [ForeignKey("AuditTypeId")]
        public virtual AuditType AuditType { get; set; } = null!;
        [ForeignKey("AuditPlanId")]
        public virtual AuditPlan AuditPlan { get; set; } = null!;
        [NotMapped]
        public string AuditTypeName { get; set; }
    }
}
