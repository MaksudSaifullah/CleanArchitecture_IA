using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardList
{
    public class GetDashboardListQueryHandler : IRequestHandler<GetDashboardListQuery, List<DashboardDTO>>
    {
        private readonly IDashboardQueryRepository _dashboardRepository;
        private readonly IMapper _mapper;

        public GetDashboardListQueryHandler(IDashboardQueryRepository dashboardRepository, IMapper mapper)
        {
            _dashboardRepository = dashboardRepository ?? throw new ArgumentNullException(nameof(dashboardRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<DashboardDTO>> Handle(GetDashboardListQuery request, CancellationToken cancellationToken)
        {
            var dashboards = await _dashboardRepository.GetAll();
            return _mapper.Map<List<DashboardDTO>>(dashboards);
        }
    }
}
