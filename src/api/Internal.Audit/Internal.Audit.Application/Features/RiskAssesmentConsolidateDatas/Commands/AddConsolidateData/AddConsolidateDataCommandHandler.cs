using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentConsolidateDatas;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentConsolidateDatas.Commands.AddConsolidateData;

public class AddConsolidateDataCommandHandler : IRequestHandler<AddConsolidateDataCommand, AddConsolidateDataResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskAssesmentConsolidateDataCommandRepository _repository;   
    private readonly IMapper _mapper;

    public AddConsolidateDataCommandHandler(IRiskAssesmentConsolidateDataCommandRepository repository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));      
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddConsolidateDataResponseDTO> Handle(AddConsolidateDataCommand request, CancellationToken cancellationToken)
    {
       
        var newRiskdataConsolidate = await _repository.Add(_mapper.Map<RiskAssesmentConsolidateData>(request));
        var rowsAffected = await _unitOfWork.CommitAsync();
        return new AddConsolidateDataResponseDTO(newRiskdataConsolidate.Id, rowsAffected > 0, rowsAffected > 0 ? "RiskAssesment consolidate  created Successfully!" : "Error while creating iskAssesment consolidate!");

    }
}
