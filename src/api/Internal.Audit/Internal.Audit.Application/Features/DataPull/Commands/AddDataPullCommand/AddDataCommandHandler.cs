using AutoMapper;
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.DataPull.Commands.AddDataPullCommand;

public class AddDataCommandHandler : IRequestHandler<AddDataCommand, AddDataPullCommandDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IBrokerService _broker;
    public AddDataCommandHandler(IMapper mapper, IBrokerService broker,
       IUnitOfWork unitOfWork)
    {

        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _broker = broker ?? throw new ArgumentNullException(nameof(broker));
    }
    public async Task<AddDataPullCommandDTO> Handle(AddDataCommand request, CancellationToken cancellationToken)
    {
        var message = new
        {
            ToDate = request.Fromdate.ToString("yyyy-MM-dd"),
            FromDate = request.Todate.ToString("yyyy-MM-dd"),
            Country = request.Country
        };
        var response = _broker.Produce(message, request.Country);

        return new AddDataPullCommandDTO(Guid.NewGuid(), response.Success ? true:false, response.Success ? "Successfully requested for data":"Failed to request for data");
    }
}
