using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;

using Internal.Audit.Domain.Entities.ProcessAndControlAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.AddRiskCriteria;

public class AddRiskCriteriaPCACommandHandler : IRequestHandler<AddRiskCriteriaPCACommand, AddRiskCriteriaPCAResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskCriteriaPCACommandRepository _riskCriteriaRepository;
    private readonly IMapper _mapper;

    public AddRiskCriteriaPCACommandHandler(IRiskCriteriaPCACommandRepository riskCriteriaRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _riskCriteriaRepository = riskCriteriaRepository ?? throw new ArgumentNullException(nameof(riskCriteriaRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddRiskCriteriaPCAResponseDTO> Handle(AddRiskCriteriaPCACommand request, CancellationToken cancellationToken)
    {
        var exists = await _riskCriteriaRepository.Get(x => (x.EffectiveFrom >= request.EffectiveFrom && x.EffectiveFrom <= request.EffectiveTo)
                                                            || (x.EffectiveTo >= request.EffectiveFrom && x.EffectiveTo <= request.EffectiveTo)
                                                            || (request.EffectiveTo >= x.EffectiveFrom && request.EffectiveTo <= x.EffectiveTo)
                                                            || (request.EffectiveFrom >= x.EffectiveFrom && request.EffectiveFrom <= x.EffectiveTo));

        var duplicateData = exists.Where(x => x.CountryId == request.CountryId);
        if (duplicateData.Count() > 0)
        {
            return new AddRiskCriteriaPCAResponseDTO(Guid.NewGuid(), false, "Duplicate Data Found in same Date Range");

        }
        var riskCriteria = _mapper.Map<RiskCriteria>(request);

        var newriskCriteria = await _riskCriteriaRepository.Add(riskCriteria);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddRiskCriteriaPCAResponseDTO(newriskCriteria.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Criteria Added Successfully!" : "Error while creating Risk Criteria !");
    }

}

