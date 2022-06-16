using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Commands.UpdateRiskProfile;
public class UpdateRiskProfileCommandHandler : IRequestHandler<UpdateRiskProfileCommand, UpdateRiskProfileResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskProfileCommandRepository _riskProfileRepository;
    private readonly IMapper _mapper;

    public UpdateRiskProfileCommandHandler(IRiskProfileCommandRepository riskProfileRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _riskProfileRepository = riskProfileRepository ?? throw new ArgumentNullException(nameof(riskProfileRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateRiskProfileResponseDTO> Handle(UpdateRiskProfileCommand request, CancellationToken cancellationToken)
    {
        var riskProfile = await _riskProfileRepository.Get(request.Id);
        var mappedRiskProfile = _mapper.Map(request, riskProfile);
        var updatedRiskProfile =  await _riskProfileRepository.Update(mappedRiskProfile);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateRiskProfileResponseDTO(updatedRiskProfile.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Profile Updated Successfully!" : "Error while updating Risk Profile!");
    }
}
