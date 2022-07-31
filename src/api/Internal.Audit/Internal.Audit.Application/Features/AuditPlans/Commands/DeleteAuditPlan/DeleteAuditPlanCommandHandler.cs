using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.DeleteAuditPlan;

public class DeleteAuditPlanCommandHandler : IRequestHandler<DeleteAuditPlanCommand, DeleteAuditPlanResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditPlanCommandRepository _AuditPlanRepository;
    private readonly IMapper _mapper;

    public DeleteAuditPlanCommandHandler(IAuditPlanCommandRepository AuditPlanRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _AuditPlanRepository = AuditPlanRepository ?? throw new ArgumentNullException(nameof(AuditPlanRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteAuditPlanResponseDTO> Handle(DeleteAuditPlanCommand request, CancellationToken cancellationToken)
    {
        var AuditPlan = await _AuditPlanRepository.Get(request.Id);
        AuditPlan.IsDeleted = true;
        var mappedAuditPlan = _mapper.Map(request, AuditPlan);
        await _AuditPlanRepository.Update(mappedAuditPlan);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteAuditPlanResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Plan Deleted Successfully!" : "Error while deleting Audit Plan!");
    }
}