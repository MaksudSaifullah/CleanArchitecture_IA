using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using Internal.Audit.Domain.Entities.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Commands.AddRiskProfile;

public class AddRiskProfileCommandHandler : IRequestHandler<AddRiskProfileCommand, AddRiskProfileResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskProfileCommandRepository _riskProfileRepository;
    private readonly IMapper _mapper;

    public AddRiskProfileCommandHandler(IRiskProfileCommandRepository riskProfileRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _riskProfileRepository = riskProfileRepository ?? throw new ArgumentNullException(nameof(riskProfileRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddRiskProfileResponseDTO> Handle(AddRiskProfileCommand request, CancellationToken cancellationToken)
    {
        //need to update this condition
        var exists =await _riskProfileRepository.Get(x => (x.EffectiveFrom >= request.EffectiveFrom && x.EffectiveFrom<=request.EffectiveTo) 
                                                            || (x.EffectiveTo >=request.EffectiveFrom && x.EffectiveTo <= request.EffectiveTo)
                                                            || (request.EffectiveTo >= x.EffectiveFrom && request.EffectiveTo <= x.EffectiveTo)
                                                            || (request.EffectiveFrom >= x.EffectiveFrom && request.EffectiveFrom <= x.EffectiveTo));

        var duplicateData = exists.Where(x => x.LikelihoodTypeId == request.LikelihoodTypeId && x.RatingTypeId == request.RatingTypeId && x.ImpactTypeId == request.ImpactTypeId);
        if(duplicateData.Count() > 0)
        {
            return new AddRiskProfileResponseDTO(Guid.NewGuid(), false, "Duplicate Data Found in same Date Range");

        }
        var riskProfile = _mapper.Map<RiskProfile>(request);
        riskProfile.IsActive = true;
        var newriskProfile = await _riskProfileRepository.Add(riskProfile);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddRiskProfileResponseDTO(newriskProfile.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Profile Added Successfully!" : "Error while creating Risk Profile !");
    }

}