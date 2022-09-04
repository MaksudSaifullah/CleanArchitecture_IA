using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.ClosingMeetingMinutes.Commands.AddClosingMeetingMinute;


public class AddClosingMeetingMinuteCommand : IRequest<AddClosingMeetingMinuteResponseDTO>
{
    public Guid? Id { get; set; }
    public string? MeetingMinutesCode { get; set; }
    public Guid AuditScheduleId { get; set; }
    public Guid BranchId { get; set; }
    public DateTime MeetingMinutesDate { get; set; }
    public string? MeetingMinutesName { get; set; }
    public string? AuditOn { get; set; }
    public string? MeetingHeld { get; set; }
    public Guid PreparedByUserId { get; set; }
    public Guid AgreedByUserId { get; set; }
    public string? SubjectMatter { get; set; }

    public List<AddMeetingPresent> ClosingMeetingPresent { get; set; }
    public List<AddMeetingApology> ClosingMeetingApology { get; set; }
    public List<AddMeetingSubject>  ClosingMeetingSubject { get; set; }

}


public record AddMeetingPresent
{
    public Guid UserId { get; set; }

    public Guid ClosingMeetingMinutesId { get; set; }
}

public record AddMeetingApology
{
    public Guid UserId { get; set; }

    public Guid ClosingMeetingMinutesId { get; set; }
}

public record AddMeetingSubject
{
    public Guid UserId { get; set; }
    public Guid ClosingMeetingMinutesId { get; set; }
    public string? SubjectMatter { get; set; }
}