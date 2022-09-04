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

namespace Internal.Audit.Application.Features.NotificationToAuditees.Commands.DeleteNotificationToAuditee;


public class DeleteNotificationToAuditeeCommandHandler : IRequestHandler<DeleteNotificationToAuditeeCommand, DeleteNotificationToAuditeeResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationToAuditeeCommandRepository _notificationToAuditeeRepository;
    private readonly INotificationToAuditeeToCommandRepository _notificationToAuditeeToRepository;
    private readonly INotificationToAuditeeCCCommandRepository _notificationToAuditeeCCRepository;
    private readonly INotificationToAuditeeBCCCommandRepository _notificationToAuditeeBCCRepository;
    private readonly IMapper _mapper;

    public DeleteNotificationToAuditeeCommandHandler(INotificationToAuditeeCommandRepository notificationToAuditeeRepository, IMapper mapper, IUnitOfWork unitOfWork,
        INotificationToAuditeeToCommandRepository notificationToAuditeeToRepository, INotificationToAuditeeCCCommandRepository notificationToAuditeeCCRepository, INotificationToAuditeeBCCCommandRepository notificationToAuditeeBCCRepository)
    {
        _notificationToAuditeeRepository = notificationToAuditeeRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeRepository));
        _notificationToAuditeeToRepository = notificationToAuditeeToRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeToRepository));
        _notificationToAuditeeCCRepository = notificationToAuditeeCCRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeCCRepository));
        _notificationToAuditeeBCCRepository = notificationToAuditeeBCCRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeeBCCRepository));

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<DeleteNotificationToAuditeeResponseDTO> Handle(DeleteNotificationToAuditeeCommand request, CancellationToken cancellationToken)
    {
        var notificationToAuditee = await _notificationToAuditeeRepository.Get(request.Id);
        if (notificationToAuditee == null)
            return new DeleteNotificationToAuditeeResponseDTO(request.Id, false, "Invalid Notification To Auditee Id");

        var mixed = _mapper.Map(request, notificationToAuditee);
        mixed.IsDeleted = true;

        await _notificationToAuditeeRepository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteNotificationToAuditeeResponseDTO(request.Id, rowsAffected > 0, "Notification To Auditee deleted successfully");
    }

}
