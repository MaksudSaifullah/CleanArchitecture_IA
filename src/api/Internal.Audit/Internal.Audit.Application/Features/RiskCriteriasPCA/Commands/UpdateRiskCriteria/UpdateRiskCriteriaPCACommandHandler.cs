using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.UpdateRiskCriteria;
public class UpdateRiskCriteriaPCACommandHandler : IRequestHandler<UpdateRiskCriteriaPCACommand, UpdateRiskCriteriaPCAResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskCriteriaPCACommandRepository _riskCriteriaRepository;
    private readonly IMapper _mapper;

    public UpdateRiskCriteriaPCACommandHandler(IRiskCriteriaPCACommandRepository riskCriteriaRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _riskCriteriaRepository = riskCriteriaRepository ?? throw new ArgumentNullException(nameof(riskCriteriaRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateRiskCriteriaPCAResponseDTO> Handle(UpdateRiskCriteriaPCACommand request, CancellationToken cancellationToken)
    {

        var exists = await _riskCriteriaRepository.Get(x => (x.EffectiveFrom >= request.EffectiveFrom && x.EffectiveFrom <= request.EffectiveTo)
                                                            || (x.EffectiveTo >= request.EffectiveFrom && x.EffectiveTo <= request.EffectiveTo)
                                                            || (request.EffectiveTo >= x.EffectiveFrom && request.EffectiveTo <= x.EffectiveTo)
                                                            || (request.EffectiveFrom >= x.EffectiveFrom && request.EffectiveFrom <= x.EffectiveTo));

        var duplicateData = exists.Where(x => x.CountryId == request.CountryId && x.Id != request.Id);
        if (duplicateData.Count() > 0)
        {
            return new UpdateRiskCriteriaPCAResponseDTO(Guid.NewGuid(), false, "Duplicate Data Found in same Date Range");

        }

        var riskCriteria = await _riskCriteriaRepository.Get(request.Id);
        var mappedRiskCriteria = _mapper.Map(request, riskCriteria);
        var updatedRiskCriteria = await _riskCriteriaRepository.Update(mappedRiskCriteria);

        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateRiskCriteriaPCAResponseDTO(updatedRiskCriteria.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Criteria Updated Successfully!" : "Error while updating Risk Criteria!");
    }
}
