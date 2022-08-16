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

        var exists = await _riskCriteriaRepository.Get(x => (x.EffectiveFrom >= request.EffectiveFrom && x.EffectiveFrom <= request.EffectiveTo)
                                                            || (x.EffectiveTo >= request.EffectiveFrom && x.EffectiveTo <= request.EffectiveTo)
                                                            || (request.EffectiveTo >= x.EffectiveFrom && request.EffectiveTo <= x.EffectiveTo)
                                                            || (request.EffectiveFrom >= x.EffectiveFrom && request.EffectiveFrom <= x.EffectiveTo));

        var duplicateData = exists.Where(x => x.CountryId == request.CountryId && x.RatingTypeId == request.RatingTypeId && x.RiskCriteriaTypeId == request.RiskCriteriaTypeId
        && request.MinimumValue <= x.MinimumValue && request.MaximumValue >= x.MaximumValue && x.Id != request.Id);
        if (duplicateData.Count() > 0)
        {
            return new UpdateRiskCriteriaResponseDTO(Guid.NewGuid(), false, "Duplicate Data Found in same Date Range");

        }

        var riskCriteria = await _riskCriteriaRepository.Get(request.Id);
        var mappedRiskCriteria = _mapper.Map(request, riskCriteria);
        var updatedRiskCriteria = await _riskCriteriaRepository.Update(mappedRiskCriteria);

        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateRiskCriteriaResponseDTO(updatedRiskCriteria.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Criteria Updated Successfully!" : "Error while updating Risk Criteria!");
    }
}
