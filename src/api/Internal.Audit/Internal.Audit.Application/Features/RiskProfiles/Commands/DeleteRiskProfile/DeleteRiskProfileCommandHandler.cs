using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Commands.DeleteRiskProfile;

public class DeleteRiskProfileCommandHandler : IRequestHandler<DeleteRiskProfileCommand, DeleteRiskProfileResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskProfileCommandRepository _RiskProfileRepository;
    private readonly IMapper _mapper;

    public DeleteRiskProfileCommandHandler(IRiskProfileCommandRepository RiskProfileRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _RiskProfileRepository = RiskProfileRepository ?? throw new ArgumentNullException(nameof(RiskProfileRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<DeleteRiskProfileResponseDTO> Handle(DeleteRiskProfileCommand request, CancellationToken cancellationToken)
    {
        var RiskProfile = await _RiskProfileRepository.Get(request.Id);
        RiskProfile.IsActive = false;
        RiskProfile.IsDeleted = true;
        var mappedRiskProfile = _mapper.Map(request, RiskProfile);
        await _RiskProfileRepository.Update(mappedRiskProfile);
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new DeleteRiskProfileResponseDTO(request.Id, rowsAffected > 0, rowsAffected > 0 ? "RiskProfile Deleted Successfully!" : "Error while deleting RiskProfile!");
    }
}