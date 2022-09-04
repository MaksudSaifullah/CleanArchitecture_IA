using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit
{
    public class CompositAuditSchedule: EntityBase
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        public string Approver { get; set; }
        public string TeamLeader { get; set; }
        public string ScheduleId { get; set; }
        public int ScheduleState { get; set; }
        public int ExecutionState { get; set; }
        public string Auditor { get; set; }
        //public string ExecutionStatus { get; set; }
        //public string ScheduleStatus { get; set; }
        public DateTime ScheduleStartDate { get; set; }
        public DateTime ScheduleEndDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
