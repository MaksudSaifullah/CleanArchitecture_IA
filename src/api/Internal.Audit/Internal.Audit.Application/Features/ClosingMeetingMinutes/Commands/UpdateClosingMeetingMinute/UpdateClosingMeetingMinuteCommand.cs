using Internal.Audit.Application.Features.AuditSchedules.Commands.UpdateSchedule;
using Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.AddClosingMeetingMinute;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.UpdateClosingMeetingMinute;



public class UpdateClosingMeetingMinuteCommand : IRequest<UpdateClosingMeetingMinuteResponseDTO>
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
    public virtual ICollection<AddMeetingPresent> UserPresents { get; set; } = null!;
    public virtual ICollection<AddMeetingApology> UserApologies { get; set; } = null!;
    public virtual ICollection<AddMeetingSubject> MeetingMinutesSubjects { get; set; } = null!;
}

