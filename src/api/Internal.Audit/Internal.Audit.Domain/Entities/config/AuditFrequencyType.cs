﻿using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.Entities.Config;

    [Table("AuditFrequencyType", Schema = "Config")]
    public class AuditFrequencyType : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

    }