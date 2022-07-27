using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
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

namespace Internal.Audit.Application.Features.DataRequestQueue.Command.AddDataRequestQueueCommand;

public class AddDataRequestCommandHandler : IRequestHandler<AddDatarequestCommand, AddDataRequestCommandDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDataRequestCommandRepository _dataRequestCommand;
    private readonly IMapper _mapper;
    private readonly ICountryQueryRepository _countryRepository;
    private readonly IBrokerService _broker;

    public AddDataRequestCommandHandler(IDataRequestCommandRepository dataRequestCommand, IMapper mapper,
        IUnitOfWork unitOfWork, ICountryQueryRepository countryRepository, IBrokerService broker)
    {
        _dataRequestCommand = dataRequestCommand ?? throw new ArgumentNullException(nameof(dataRequestCommand));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _broker = broker ?? throw new ArgumentNullException(nameof(broker));
    }
    public async Task<AddDataRequestCommandDTO> Handle(AddDatarequestCommand request, CancellationToken cancellationToken)
    {
        var isPending =await _dataRequestCommand.Get(x => x.Status == 1 && x.CountryId == request.CountryId);
        if (isPending.Count > 0)
        {
            return new AddDataRequestCommandDTO(Guid.NewGuid(), false,"Data already in queue");

        }
        var dataPullrequest = _mapper.Map<DataRequestQueueService>(request);
        dataPullrequest.IsActive = true;
        dataPullrequest.RequestedOn = DateTime.Now;
        dataPullrequest.Status = (int)AppConstants.RequestStatus.REQUESTED;
        dataPullrequest.Id = Guid.NewGuid();
        await _dataRequestCommand.Add(dataPullrequest);

        var country = await _countryRepository.GetById(request.CountryId);

        var message = new
        {
            ToDate = request.ToDate.ToString("yyyy-MM-dd"),
            FromDate = request.FromDate.ToString("yyyy-MM-dd"),
            Country = request.CountryId,
            CountryName = country.Name,
            DataRequestQueueServiceId = dataPullrequest.Id
        };
        var response = _broker.Produce(message, country.Name+"-IA");

        if (response.Success)
        {
            var rowsAffected = await _unitOfWork.CommitAsync();
            return new AddDataRequestCommandDTO(dataPullrequest.Id, rowsAffected > 0, rowsAffected > 0 ? "Data pull request Added Successfully!" : "Error while creating Data pull request!");

        }

        return new AddDataRequestCommandDTO(Guid.NewGuid(), false, "Can't add to RabbitMQ");

    }
}
