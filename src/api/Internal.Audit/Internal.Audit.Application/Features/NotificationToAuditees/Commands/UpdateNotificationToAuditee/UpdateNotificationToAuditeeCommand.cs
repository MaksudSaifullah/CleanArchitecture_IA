using Internal.Audit.Application.Features.NotificationToAuditees.Commands.AddNotificationToAuditee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.NotificationToAuditees.Commands.UpdateNotificationToAuditee;



public class UpdateNotificationToAuditeeCommand : IRequest<UpdateNotificationToAuditeeResponseDTO>
{
    public Guid Id { get; set; }
    public Guid AuditCreationId { get; set; }

    public List<AddNotifedUsersTo> NotificationToUsersTo { get; set; }
    public List<AddNotifedUsersCC> NotificationToUsersCC { get; set; }
    public List<AddNotifedUsersBCC> NotificationToUsersBCC { get; set; }
}
