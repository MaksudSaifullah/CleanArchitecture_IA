using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Commands.UpdateRiskCriteria;
public class UpdateRiskCriteriaCommandHandler : IRequestHandler<UpdateRiskCriteriaCommand, UpdateRiskCriteriaResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskCriteriaCommandRepository _riskCriteriaRepository;
    private readonly IMapper _mapper;

    public UpdateRiskCriteriaCommandHandler(IRiskCriteriaCommandRepository riskCriteriaRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _riskCriteriaRepository = riskCriteriaRepository ?? throw new ArgumentNullException(nameof(riskCriteriaRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateRiskCriteriaResponseDTO> Handle(UpdateRiskCriteriaCommand request, CancellationToken cancellationToken)
    {
        var riskCriteria = await _riskCriteriaRepository.Get(request.Id);
        var mappedRiskCriteria = _mapper.Map(request, riskCriteria);
        var updatedRiskCriteria = await _riskCriteriaRepository.Update(mappedRiskCriteria);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateRiskCriteriaResponseDTO(updatedRiskCriteria.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Criteria Updated Successfully!" : "Error while updating Risk Criteria!");
    }
}
