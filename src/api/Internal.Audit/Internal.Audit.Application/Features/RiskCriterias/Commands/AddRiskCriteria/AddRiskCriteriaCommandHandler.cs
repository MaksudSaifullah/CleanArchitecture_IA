using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;

using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Commands.AddRiskCriteria;

public class AddRiskCriteriaCommandHandler : IRequestHandler<AddRiskCriteriaCommand, AddRiskCriteriaResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskCriteriaCommandRepository _riskCriteriaRepository;
    private readonly IMapper _mapper;

    public AddRiskCriteriaCommandHandler(IRiskCriteriaCommandRepository riskCriteriaRepository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _riskCriteriaRepository = riskCriteriaRepository ?? throw new ArgumentNullException(nameof(riskCriteriaRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddRiskCriteriaResponseDTO> Handle(AddRiskCriteriaCommand request, CancellationToken cancellationToken)
    {
        var riskCriteria = _mapper.Map<RiskCriteria>(request);
        var newriskCriteria = await _riskCriteriaRepository.Add(riskCriteria);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddRiskCriteriaResponseDTO(newriskCriteria.Id, rowsAffected > 0, rowsAffected > 0 ? "Risk Criteria Added Successfully!" : "Error while creating Risk Criteria !");
    }

}

