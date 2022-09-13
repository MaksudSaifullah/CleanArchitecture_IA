﻿using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlans;
using Internal.Audit.Application.Contracts.Persistent.IssueValidationActionPlanTestSheets;
using Internal.Audit.Application.Contracts.Persistent.IssueValidationDesignEffectiveNessTestDetails;
using Internal.Audit.Application.Contracts.Persistent.IssueValidationEvidenceDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.DeleteActionPlans;

public class DeleteActionPlanCommandHandler : IRequestHandler<DeleteActionPlanCommand, DeleteActionPlanCommandResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IIssueValidationActionPlanCommandRepository _repository;
    private readonly IIssueValidationTestCheetCommandRepository _repositoryTextCheet;
    private readonly IIssueValidationDesignEffectiveNessCommandRespository _repositoryDesignEffectiveness;
    private readonly IIssueValidationEvidenceDetailCommandRepository _repositoryEvidenceDetail;
    private readonly IMapper _mapper;

    public DeleteActionPlanCommandHandler(IIssueValidationActionPlanCommandRepository repository, IMapper mapper, IUnitOfWork unitOfWork, IIssueValidationTestCheetCommandRepository repositoryTextCheet,
        IIssueValidationDesignEffectiveNessCommandRespository repositoryDesignEffectiveness,
        IIssueValidationEvidenceDetailCommandRepository repositoryEvidenceDetail)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _repositoryTextCheet = repositoryTextCheet ?? throw new ArgumentNullException(nameof(repositoryTextCheet));
        _repositoryDesignEffectiveness = repositoryDesignEffectiveness ?? throw new ArgumentNullException(nameof(repositoryDesignEffectiveness));
        _repositoryEvidenceDetail = repositoryEvidenceDetail ?? throw new ArgumentNullException(nameof(repositoryEvidenceDetail));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<DeleteActionPlanCommandResponseDTO> Handle(DeleteActionPlanCommand request, CancellationToken cancellationToken)
    {
        var auditActionPlan = await _repository.Get(request.Id);
        if (auditActionPlan == null)
            return new DeleteActionPlanCommandResponseDTO(request.Id, false, "Invalid action plan Id");

        //await _repositoryTextCheet.Update(_repositoryTextCheet.Get(x => x.IssueValidationActionPlanId == request.Id).Result.ToList());
        //await _repositoryDesignEffectiveness.Delete(_repositoryDesignEffectiveness.Get(x => x.IssueValidationActionPlanId == request.Id).Result.ToList());
        //await _repositoryEvidenceDetail.Delete(_repositoryEvidenceDetail.Get(x => x.IssueValidationActionPlanId == request.Id).Result.ToList());
        auditActionPlan.IsDeleted = true;
       
        await _repository.Update(auditActionPlan);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteActionPlanCommandResponseDTO(request.Id, rowsAffected > 0, "Updated action plan Id");
        
    }
}
