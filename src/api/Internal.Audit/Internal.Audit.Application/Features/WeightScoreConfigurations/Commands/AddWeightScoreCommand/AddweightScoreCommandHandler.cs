using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.WeightScoreConfigurations;
using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WeightScoreConfigurations.Commands.AddWeightScoreCommand;

public class AddweightScoreCommandHandler : IRequestHandler<AddweightScoreCommand, AddWeightScoreResponseDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWeightScoreConfigurationCommandRepository _repository;
    private readonly IMapper _mapper;

    public AddweightScoreCommandHandler(IWeightScoreConfigurationCommandRepository repository, IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<AddWeightScoreResponseDTO> Handle(AddweightScoreCommand request, CancellationToken cancellationToken)
    {       
        var existsDataList = await _repository.Get(x => x.CountryId == request.WeightScoreData.FirstOrDefault().CountryId);
        if(existsDataList != null)
        {
            await _repository.Delete(existsDataList);
        }
        var UploadDocument = _mapper.Map<IEnumerable<WeightScore>>(request.WeightScoreData);
        var newUploaweightScore = await _repository.Add(UploadDocument);
        var rowsAffected = await _unitOfWork.CommitAsync();

        return new AddWeightScoreResponseDTO(Guid.NewGuid(), rowsAffected > 0, rowsAffected > 0 ? "Weight score added Successfully!" : "Error while adding Weight score");
    }
}
