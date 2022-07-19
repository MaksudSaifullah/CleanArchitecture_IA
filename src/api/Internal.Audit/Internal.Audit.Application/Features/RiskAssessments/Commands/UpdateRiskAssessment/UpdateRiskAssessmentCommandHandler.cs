using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Commands.UpdateRiskAssessment;
public class UpdateRiskAssessmentCommandHandler : IRequestHandler<UpdateRiskAssessmentCommand, UpdateRiskAssessmentResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskAssessmentCommandRepository _riskAssessmentRepository;
    private readonly IMapper _mapper;

    public UpdateRiskAssessmentCommandHandler(IRiskAssessmentCommandRepository riskAssessmentRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _riskAssessmentRepository = riskAssessmentRepository ?? throw new ArgumentNullException(nameof(riskAssessmentRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateRiskAssessmentResponseDTO> Handle(UpdateRiskAssessmentCommand request, CancellationToken cancellationToken)
    {
        var riskAssessment = await _riskAssessmentRepository.Get(request.Id);
        var mappedRiskAssessment = _mapper.Map(request, riskAssessment);
        var updatedRiskAssessment = await _riskAssessmentRepository.Update(mappedRiskAssessment);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateRiskAssessmentResponseDTO(updatedRiskAssessment.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Assessment Updated Successfully!" : "Error while updating Risk Assessment!");
    }
}
