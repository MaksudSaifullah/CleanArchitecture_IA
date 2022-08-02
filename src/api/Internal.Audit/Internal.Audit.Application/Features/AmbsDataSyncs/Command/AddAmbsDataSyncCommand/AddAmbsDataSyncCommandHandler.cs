using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AmbsDataSync;
using Internal.Audit.Application.Contracts.Persistent.Branches;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Contracts.Persistent.DataRequestQueue;
using Internal.Audit.Domain.Constants;
using Internal.Audit.Domain.Entities.security;
using MediatR;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Command.AddAmbsDataSyncCommand;

public class AddAmbsDataSyncCommandHandler : IRequestHandler<AddAmbsDataSyncCommand, AddAmbsDataSyncCommandDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAmbsDataSyncCommandRepository _dataSyncCommand;
    private readonly IMapper _mapper;
    private readonly ICountryQueryRepository _countryRepository;
    private readonly IDataRequestCommandRepository _dataRequestCommand;
    private readonly IBranchCommandRepository _branchRepository;
    public AddAmbsDataSyncCommandHandler(IAmbsDataSyncCommandRepository dataSyncCommand, IMapper mapper,
        IUnitOfWork unitOfWork, ICountryQueryRepository countryRepository, IDataRequestCommandRepository dataRequestCommand, IBranchCommandRepository branchRepository)
    {
        _dataRequestCommand = dataRequestCommand ?? throw new ArgumentNullException(nameof(dataRequestCommand));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _dataSyncCommand = dataSyncCommand ?? throw new ArgumentNullException(nameof(dataSyncCommand));
        _branchRepository = branchRepository ?? throw new ArgumentNullException(nameof(branchRepository));

    }
    public async Task<AddAmbsDataSyncCommandDTO> Handle(AddAmbsDataSyncCommand request, CancellationToken cancellationToken)
    {
        Guid DataRequestQueueServiceId = Guid.Empty;
        int CommonValueTableId = 0;
        if (request.DataGet.Count > 0)
        {
            DataRequestQueueServiceId = request.DataGet.FirstOrDefault().DataRequestQueueServiceId;
            CommonValueTableId = request.DataGet.FirstOrDefault().CommonValueTableId;
            var dataSyncExists = await _dataSyncCommand.Get(x => x.DataRequestQueueServiceId == DataRequestQueueServiceId && x.CommonValueTableId == CommonValueTableId);
            if (dataSyncExists.Count > 0)
            {
                return new AddAmbsDataSyncCommandDTO(Guid.NewGuid(), false, "Data already exists");

            }

            var dataPullrequest = _mapper.Map<IList<AmbsDataSync>>(request.DataGet);
            await _dataSyncCommand.Add(dataPullrequest);
            var updateDataRequest = await _dataRequestCommand.Get(DataRequestQueueServiceId);
            updateDataRequest.Status = (int)AppConstants.RequestStatus.PROCESSED;

            var universalCountryId= await _dataRequestCommand.Get(DataRequestQueueServiceId);
            request.DataGet.ToList().ForEach(x => x.CountryId = universalCountryId.CountryId);
            foreach (var requestBranch in request.DataGet)
            {
                var extsts = await _branchRepository.Get(x => x.CountryId == universalCountryId.CountryId && x.BranchCode == requestBranch.BranchCode);
                if (extsts.Count() == 0)
                {
                    var branch = _mapper.Map<Branch>(requestBranch);
                   var newbranch = await _branchRepository.Add(branch);                    
                }
            }

            var rowsAffected = await _unitOfWork.CommitAsync();
            return new AddAmbsDataSyncCommandDTO(Guid.NewGuid(), rowsAffected > 0, rowsAffected > 0 ? "Data synced Successfully!" : "Error while syncing Data!");

        }

        return new AddAmbsDataSyncCommandDTO(Guid.NewGuid(), false, "Empty data received");
    }
}
