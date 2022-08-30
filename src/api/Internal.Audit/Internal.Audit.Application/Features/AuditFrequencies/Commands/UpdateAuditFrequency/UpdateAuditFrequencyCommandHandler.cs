using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditFrequencies.Commands.UpdateAuditFrequency;
public class UpdateAuditFrequencyCommandHandler : IRequestHandler<UpdateAuditFrequencyCommand, UpdateAuditFrequencyResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuditFrequencyCommandRepository _auditfrequencyRepository;
    private readonly IMapper _mapper;

    public UpdateAuditFrequencyCommandHandler(IAuditFrequencyCommandRepository auditfrequencyRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _auditfrequencyRepository = auditfrequencyRepository ?? throw new ArgumentNullException(nameof(auditfrequencyRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<UpdateAuditFrequencyResponseDTO> Handle(UpdateAuditFrequencyCommand request, CancellationToken cancellationToken)
    {
        var exists = await _auditfrequencyRepository.Get(x => (x.EffectiveFrom >= request.EffectiveFrom && x.EffectiveFrom <= request.EffectiveTo)
                                                            || (x.EffectiveTo >= request.EffectiveFrom && x.EffectiveTo <= request.EffectiveTo)
                                                            || (request.EffectiveTo >= x.EffectiveFrom && request.EffectiveTo <= x.EffectiveTo)
                                                            || (request.EffectiveFrom >= x.EffectiveFrom && request.EffectiveFrom <= x.EffectiveTo));

        var duplicateData = exists.Where(x => x.CountryId == request.CountryId && x.RatingTypeId == request.RatingTypeId && x.AuditScoreId == request.AuditScoreId && x.Id != request.Id);
        if (duplicateData.Count() > 0)
        {
            return new UpdateAuditFrequencyResponseDTO(Guid.NewGuid(), false, "Duplicate Data Found in same Date Range");

        }

        var AuditFrequency = await _auditfrequencyRepository.Get(request.Id);
        var mappedAuditFrequency = _mapper.Map(request, AuditFrequency);
        var updatedAuditFrequency = await _auditfrequencyRepository.Update(mappedAuditFrequency);

        var rowsAffected = await _unitOfWork.CommitAsync();
        return new UpdateAuditFrequencyResponseDTO(updatedAuditFrequency.Id, rowsAffected > 0, rowsAffected > 0 ? "Audit Frequency Updated Successfully!" : "Error while updating Audit Frequency!");
    


    }
}
