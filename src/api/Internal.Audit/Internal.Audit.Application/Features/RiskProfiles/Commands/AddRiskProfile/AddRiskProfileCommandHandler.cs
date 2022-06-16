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
        var riskProfile = _mapper.Map<RiskProfile>(request);
        var newriskProfile = await _riskProfileRepository.Add(riskProfile);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddRiskProfileResponseDTO(newriskProfile.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Profile Added Successfully!" : "Error while creating Risk Profile !");
    }

}