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

namespace Internal.Audit.Application.Features.NotificationToAuditees.Commands.UpdateNotificationToAuditee;


public class UpdateNotificationToAuditeeCommandHandler : IRequestHandler<UpdateNotificationToAuditeeCommand, UpdateNotificationToAuditeeResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationToAuditeeCommandRepository _notificationToAuditeeRepository;
    private readonly INotificationToAuditeeToCommandRepository _notificationToAuditeeToRepository;
    private readonly INotificationToAuditeeCCCommandRepository _notificationToAuditeeCCRepository;
    private readonly INotificationToAuditeeBCCCommandRepository _notificationToAuditeeBCCRepository;
    private readonly IMapper _mapper;

    public UpdateNotificationToAuditeeCommandHandler(INotificationToAuditeeCommandRepository notificationToAuditeeRepository, IMapper mapper, IUnitOfWork unitOfWork,
        INotificationToAuditeeToCommandRepository notificationToAuditeeToRepository, INotificationToAuditeeCCCommandRepository notificationToAuditeeCCRepository, INotificationToAuditeeBCCCommandRepository notificationToAuditeeBCCRepository)
    {
        _notificationToAuditeeRepository = notificationToAuditeeRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeRepository));
        _notificationToAuditeeToRepository = notificationToAuditeeToRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeToRepository));
        _notificationToAuditeeCCRepository = notificationToAuditeeCCRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeCCRepository));
        _notificationToAuditeeBCCRepository = notificationToAuditeeBCCRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeBCCRepository));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<UpdateNotificationToAuditeeResponseDTO> Handle(UpdateNotificationToAuditeeCommand request, CancellationToken cancellationToken)
    {

        var notificationToAuditee = await _notificationToAuditeeRepository.Get(request.Id);
        if (notificationToAuditee == null)
            return new UpdateNotificationToAuditeeResponseDTO(request.Id, false, "Invalid Invalid Notification To Auditee");
        await _notificationToAuditeeToRepository.Delete(_notificationToAuditeeToRepository.Get(x => x.NotificationToAuditeeId == request.Id).Result.ToList());
        await _notificationToAuditeeCCRepository.Delete(_notificationToAuditeeCCRepository.Get(x => x.NotificationToAuditeeId == request.Id).Result.ToList());
        await _notificationToAuditeeBCCRepository.Delete(_notificationToAuditeeBCCRepository.Get(x => x.NotificationToAuditeeId == request.Id).Result.ToList());

        var mixed = _mapper.Map(request, notificationToAuditee);
        await _notificationToAuditeeRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new UpdateNotificationToAuditeeResponseDTO(request.Id, rowsAffected > 0, "Updated audit schedule Id");

    }

}
