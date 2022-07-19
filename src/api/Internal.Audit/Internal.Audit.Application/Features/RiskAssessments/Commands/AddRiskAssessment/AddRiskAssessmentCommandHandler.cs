using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Commands.AddRiskAssessment;

public class AddRiskAssessmentCommandHandler : IRequestHandler<AddRiskAssessmentCommand, AddRiskAssessmentResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskAssessmentCommandRepository _riskAssessmentRepository;
    private readonly IMapper _mapper;

    public AddRiskAssessmentCommandHandler(IRiskAssessmentCommandRepository riskAssessmentRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _riskAssessmentRepository = riskAssessmentRepository ?? throw new ArgumentNullException(nameof(riskAssessmentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddRiskAssessmentResponseDTO> Handle(AddRiskAssessmentCommand request, CancellationToken cancellationToken)
    {
        var riskAssessment = _mapper.Map<RiskAssessment>(request);
        var newriskAssessment = await _riskAssessmentRepository.Add(riskAssessment);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddRiskAssessmentResponseDTO(newriskAssessment.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Assessment Added Successfully!" : "Error while creating Risk Assessment !");
    }

}