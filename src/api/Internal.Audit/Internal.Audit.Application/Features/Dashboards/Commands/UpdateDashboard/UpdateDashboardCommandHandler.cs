using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Commands.UpdateDashboard;
public class UpdateDashboardCommandHandler : IRequestHandler<UpdateDashboardCommand, UpdateDashboardResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDashboardCommandRepository _dashboardRepository;
    private readonly IMapper _mapper;

    public UpdateDashboardCommandHandler(IDashboardCommandRepository dashboardRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _dashboardRepository = dashboardRepository ?? throw new ArgumentNullException(nameof(dashboardRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateDashboardResponseDTO> Handle(UpdateDashboardCommand request, CancellationToken cancellationToken)
    {
        var dashboard = await _dashboardRepository.Get(request.Id);

        var mappedDashboard = _mapper.Map(request, dashboard);
        var updatedDashboard = await _dashboardRepository.Update(mappedDashboard);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateDashboardResponseDTO(updatedDashboard.Id, rowsAffected > 0, rowsAffected > 0 ? "Dashboard Updated Successfully!" : "Error while updating Dashboard!");
    }
}
