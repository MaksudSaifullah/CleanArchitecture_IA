using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.NotificationToAuditees;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.NotificationToAuditees.Queries.GetNotificationToAuditeeList;

public class GetNotificationToAuditeeListQueryHandler : IRequestHandler<GetNotificationToAuditeeListQuery, NotificationToAuditeeListPagingDTO>
{
    private readonly INotificationToAuditeeQueryRepository _notificationToAuditeesRepository;
    private readonly IMapper _mapper;

    public GetNotificationToAuditeeListQueryHandler(INotificationToAuditeeQueryRepository notificationToAuditeesRepository, IMapper mapper)
    {
        _notificationToAuditeesRepository = notificationToAuditeesRepository ?? throw new ArgumentNullException(nameof(notificationToAuditeesRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<NotificationToAuditeeListPagingDTO> Handle(GetNotificationToAuditeeListQuery request, CancellationToken cancellationToken)
    {
        (long, IEnumerable<CompositeNotificationToAuditee>) result = await _notificationToAuditeesRepository.GetAll(request.pageSize, request.pageNumber, request.searchTerm);

        var notificationToAuditeeList = _mapper.Map<List<NotificationToAuditeeDTO>>(result.Item2);

        return new NotificationToAuditeeListPagingDTO { Items = notificationToAuditeeList, TotalCount = result.Item1 };
    }


}
