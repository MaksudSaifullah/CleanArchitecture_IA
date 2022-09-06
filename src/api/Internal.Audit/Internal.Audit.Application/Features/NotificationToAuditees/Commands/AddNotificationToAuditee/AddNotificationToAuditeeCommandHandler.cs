using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.NotificationToAuditees;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.NotificationToAuditees.Commands.AddNotificationToAuditee;


public class AddNotificationToAuditeeCommandHandler : IRequestHandler<AddNotificationToAuditeeCommand, AddNotificationToAuditeeResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationToAuditeeCommandRepository _notificationToAuditeeRepository;
    private readonly INotificationToAuditeeToCommandRepository _notificationToAuditeeToRepository;
    private readonly INotificationToAuditeeCCCommandRepository _notificationToAuditeeCCRepository;
    private readonly INotificationToAuditeeBCCCommandRepository _notificationToAuditeeBCCRepository;
    private readonly IMapper _mapper;

    public AddNotificationToAuditeeCommandHandler(INotificationToAuditeeCommandRepository notificationToAuditeeRepository, IMapper mapper, IUnitOfWork unitOfWork,
        INotificationToAuditeeToCommandRepository notificationToAuditeeToRepository, INotificationToAuditeeCCCommandRepository notificationToAuditeeCCRepository, INotificationToAuditeeBCCCommandRepository notificationToAuditeeBCCRepository)
    {
        _notificationToAuditeeRepository = notificationToAuditeeRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeRepository));
        _notificationToAuditeeToRepository = notificationToAuditeeToRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeToRepository));
        _notificationToAuditeeCCRepository = notificationToAuditeeCCRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeCCRepository));
        _notificationToAuditeeBCCRepository = notificationToAuditeeBCCRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeBCCRepository));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddNotificationToAuditeeResponseDTO> Handle(AddNotificationToAuditeeCommand request, CancellationToken cancellationToken)
    {
        var gid = Guid.NewGuid();
        request.Id = gid;

        var notificationToAuditee = _mapper.Map<NotificationToAuditee>(request);
        var notificationToAuditeeAdd = await _notificationToAuditeeRepository.Add(notificationToAuditee);

        request.NotificationToUsersTo.ForEach(i => i.NotificationToAuditeeId = gid);
        var notificationToUsersTo = _mapper.Map<List<NotifedUsersTo>>(request.NotificationToUsersTo);
        await _notificationToAuditeeToRepository.Add(notificationToUsersTo);
        
        request.NotificationToUsersCC.ForEach(i => i.NotificationToAuditeeId = gid);
        var notificationToUsersCC = _mapper.Map<List<NotifedUsersCC>>(request.NotificationToUsersCC);
        await _notificationToAuditeeCCRepository.Add(notificationToUsersCC);

        request.NotificationToUsersBCC.ForEach(i => i.NotificationToAuditeeId = gid);
        var notificationToUsersBCC = _mapper.Map<List<NotifedUsersBCC>>(request.NotificationToUsersBCC);
        await _notificationToAuditeeBCCRepository.Add(notificationToUsersBCC);



        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddNotificationToAuditeeResponseDTO(notificationToAuditeeAdd.Id, rowsAffected > 0, rowsAffected > 0 ? "Notification To Auditee Added Successfully!" : "Error while creating Notification To Auditee !");
    }

}
