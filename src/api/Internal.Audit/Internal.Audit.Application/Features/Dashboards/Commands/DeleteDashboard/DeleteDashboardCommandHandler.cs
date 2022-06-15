using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Commands.DeleteDashboard;

public class DeleteDashboardCommandHandler : IRequestHandler<DeleteDashboardCommand, DeleteDashboardResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDashboardCommandRepository _dashboardRepository;
    private readonly IMapper _mapper;

    public DeleteDashboardCommandHandler(IDashboardCommandRepository dashboardRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _dashboardRepository = dashboardRepository ?? throw new ArgumentNullException(nameof(dashboardRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteDashboardResponseDTO> Handle(DeleteDashboardCommand request, CancellationToken cancellationToken)
    {
        var dashboard = await _dashboardRepository.Get(request.Id);
        dashboard.Status = false;
        dashboard.IsDeleted = true;
        var mappedDashboard = _mapper.Map(request, dashboard);
        await _dashboardRepository.Update(mappedDashboard);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteDashboardResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Dashboard Deleted Successfully!" : "Error while deleting Dashboard!");
    }
}