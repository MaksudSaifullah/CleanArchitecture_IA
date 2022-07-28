using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.AmbsDataSync;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Contracts.Persistent.DataRequestQueue;
using Internal.Audit.Domain.Constants;
using Internal.Audit.Domain.Entities.security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AmbsDataSyncs.Command.AddAmbsDataSyncCommand;

public class AddAmbsDataSyncCommandHandler : IRequestHandler<AddAmbsDataSyncCommand, AddAmbsDataSyncCommandDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAmbsDataSyncCommandRepository _dataSyncCommand;
    private readonly IMapper _mapper;
    private readonly ICountryQueryRepository _countryRepository;
    private readonly IDataRequestCommandRepository _dataRequestCommand;

    public AddAmbsDataSyncCommandHandler(IAmbsDataSyncCommandRepository dataSyncCommand, IMapper mapper,
        IUnitOfWork unitOfWork, ICountryQueryRepository countryRepository, IDataRequestCommandRepository dataRequestCommand)
    {
        _dataRequestCommand = dataRequestCommand ?? throw new ArgumentNullException(nameof(dataRequestCommand));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _dataSyncCommand = dataSyncCommand ?? throw new ArgumentNullException(nameof(dataSyncCommand));

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
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new AddAmbsDataSyncCommandDTO(Guid.NewGuid(), rowsAffected > 0, rowsAffected > 0 ? "Data synced Successfully!" : "Error while syncing Data!");

        }

        return new AddAmbsDataSyncCommandDTO(Guid.NewGuid(), false, "Empty data received");
    }
}
