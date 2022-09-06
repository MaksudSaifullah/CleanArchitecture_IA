using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Queries.GetClosingMeetingMinuteList
{
    public record ClosingMeetingMinuteDTO
    {
        public Guid Id { get; set; }
        public string? MeetingMinutesCode { get; set; }
        public Guid AuditScheduleId { get; set; }
        public Guid AuditScheduleBranchId { get; set; }
        public DateTime MeetingMinutesDate { get; set; }
        public string? MeetingMinutesName { get; set; }
        public string? AuditOn { get; set; }
        public string? MeetingHeld { get; set; }
        public Guid PreparedByUserId { get; set; }
        public Guid AgreedByUserId { get; set; }
        public string? AgreedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? SubjectMatter { get; set; }
        public Guid MeetingSubjectId { get; set; }
    }

}
