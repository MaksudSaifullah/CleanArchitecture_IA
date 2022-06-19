using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Domain.Entities.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Commands.AddDashboard;

public class AddDashboardCommandHandler : IRequestHandler<AddDashboardCommand, AddDashboardResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDashboardCommandRepository _dashboardRepository;
    private readonly IMapper _mapper;

    public AddDashboardCommandHandler(IDashboardCommandRepository dashboardRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _dashboardRepository = dashboardRepository ?? throw new ArgumentNullException(nameof(dashboardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddDashboardResponseDTO> Handle(AddDashboardCommand request, CancellationToken cancellationToken)
    {
        var dashboard = _mapper.Map<DashBoardBase>(request);
        var newDashboard = await _dashboardRepository.Add(dashboard);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddDashboardResponseDTO(newDashboard.Id, rowsAffected > 0, rowsAffected > 0 ? "Dashboard Added Successfully!" : "Error while creating Dashboard!");
    }

}
