using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Internal.Audit.Application.Features.NotificationToAuditees.Commands.AddNotificationToAuditee;


public class AddNotificationToAuditeeCommand : IRequest<AddNotificationToAuditeeResponseDTO>
{
    public Guid? Id { get; set; }
    public Guid AuditCreationId { get; set; }

    public List<AddNotifedUsersTo> NotificationToUsersTo { get; set; }
    public List<AddNotifedUsersCC> NotificationToUsersCC { get; set; }
    public List<AddNotifedUsersBCC> NotificationToUsersBCC { get; set; }

}


public record AddNotifedUsersTo
{
    public Guid UserId { get; set; }

    public Guid NotificationToAuditeeId { get; set; }
}

public record AddNotifedUsersCC
{
    public Guid UserId { get; set; }

    public Guid NotificationToAuditeeId { get; set; }
}

public record AddNotifedUsersBCC
{
    public Guid UserId { get; set; }
    public Guid NotificationToAuditeeId { get; set; }
    
}