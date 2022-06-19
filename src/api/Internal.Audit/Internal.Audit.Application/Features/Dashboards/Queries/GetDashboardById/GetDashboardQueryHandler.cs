using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardById;
public class GetDashboardQueryHandler : IRequestHandler<GetDashboardQuery, DashboardByIdDTO>
{
    private readonly IDashboardQueryRepository _dashboardRepository;
    private readonly IMapper _mapper;

    public GetDashboardQueryHandler(IDashboardQueryRepository dashboardRepository, IMapper mapper)
    {
        _dashboardRepository = dashboardRepository ?? throw new ArgumentNullException(nameof(dashboardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DashboardByIdDTO> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
    {
        var dashboard = await _dashboardRepository.GetById(request.Id);
        return _mapper.Map<DashboardByIdDTO>(dashboard);
    }
}
