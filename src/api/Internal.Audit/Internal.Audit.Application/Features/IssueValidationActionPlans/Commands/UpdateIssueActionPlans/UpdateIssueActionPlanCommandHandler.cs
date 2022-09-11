using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlans;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.UpdateIssueActionPlans;

public class UpdateIssueActionPlanCommandHandler : IRequestHandler<UpdateIssueActionPlanCommand, UpdateIssueActionPlanResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIssueValidationActionPlanCommandRepository _repository;
    private readonly IMapper _mapper;

    public UpdateIssueActionPlanCommandHandler(IIssueValidationActionPlanCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<UpdateIssueActionPlanResponseDTO> Handle(UpdateIssueActionPlanCommand request, CancellationToken cancellationToken)
    {
        var auditActionPlan = await _repository.Get(request.Id);
        if (auditActionPlan == null)
            return new UpdateIssueActionPlanResponseDTO(request.Id, false, "Invalid action plan Id");
        
        //await _auditscheduleparticipantRepository.Delete(_auditscheduleparticipantRepository.Get(x => x.AuditScheduleId == request.Id).Result.ToList());
        //await _auditscheduleBranchRepository.Delete(_auditscheduleBranchRepository.Get(x => x.AuditScheduleId == request.Id).Result.ToList());

        var mixed = _mapper.Map(request, auditActionPlan);
        await _repository.Update(mixed);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new UpdateIssueActionPlanResponseDTO(request.Id, rowsAffected > 0, "Updated action plan Id");
    }
}
