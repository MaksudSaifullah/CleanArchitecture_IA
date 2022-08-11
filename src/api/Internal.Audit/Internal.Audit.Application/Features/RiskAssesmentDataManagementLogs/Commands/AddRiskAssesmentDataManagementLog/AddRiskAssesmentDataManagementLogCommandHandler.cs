using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagements;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssesmentDataManagementLogs.Commands.AddRiskAssesmentDataManagementLog;

public class AddRiskAssesmentDataManagementLogCommandHandler : IRequestHandler<AddRiskAssesmentDataManagementLogCommand, AddRiskAssesmentDataManagementLogResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRiskAssesmentDataManagementLogCommandRepository _repository;
    private readonly IRiskAssesmentDataManagementCommandRepository _repositoryManagement;
    private readonly IMapper _mapper;

    public AddRiskAssesmentDataManagementLogCommandHandler(IRiskAssesmentDataManagementLogCommandRepository repository, IMapper mapper,
        IUnitOfWork unitOfWork, IRiskAssesmentDataManagementCommandRepository repositoryManagement)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _repositoryManagement = repositoryManagement ?? throw new ArgumentNullException(nameof(repositoryManagement));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddRiskAssesmentDataManagementLogResponseDTO> Handle(AddRiskAssesmentDataManagementLogCommand request, CancellationToken cancellationToken)
    {

        var listOfExistsItem =await _repository.Get(x => x.DataRequestQueueServiceId == request.DataRequestQueueServiceId && x.TypeId==request.TypeId);
        if (listOfExistsItem.FirstOrDefault() != null)
        {
            var listOfItemsNeedtoDelete = await _repositoryManagement.Get(x => x.RiskAssesmentDataManagementLogId == listOfExistsItem.FirstOrDefault().Id);
            if (listOfItemsNeedtoDelete != null)
            {
                await _repository.Delete(listOfExistsItem.FirstOrDefault());
               await _repositoryManagement.Delete(listOfItemsNeedtoDelete);
            }
        }

       
        var riskdataManagementLog = _mapper.Map<RiskAssesmentDataManagementLog>(request);       
        var newRiskdataManagementLog= await _repository.Add(riskdataManagementLog);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddRiskAssesmentDataManagementLogResponseDTO(newRiskdataManagementLog.Id, rowsAffected > 0, rowsAffected > 0 ? "RiskAssesmentDataManagement Log created Successfully!" : "Error while creating RiskAssesmentDataManagement Log !");

    }
}
