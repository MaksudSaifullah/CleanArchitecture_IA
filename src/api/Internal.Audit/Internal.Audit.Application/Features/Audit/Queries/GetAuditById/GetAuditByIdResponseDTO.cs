﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Audit.Queries.GetAuditById
{
    public record GetAuditByIdResponseDTO
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid AuditTypeId { get; set; }
        public Guid AuditPlanId { get; set; }
        public string AuditId { get; set; }
        public Int32 Year { get; set; }
        public string AuditName { get; set; }
        public DateTime AuditPeriodFrom { get; set; }
        public DateTime AuditPeriodTo { get; set; }
    }
}
