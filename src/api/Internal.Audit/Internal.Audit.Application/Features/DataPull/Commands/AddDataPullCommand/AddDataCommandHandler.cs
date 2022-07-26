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
    public AddDataCommandHandler( IMapper mapper, IBrokerService broker,
       IUnitOfWork unitOfWork)
    {
       
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _broker= broker ?? throw new ArgumentNullException(nameof(broker));
    }
    public Task<AddDataPullCommandDTO> Handle(AddDataCommand request, CancellationToken cancellationToken)
    {
        var message = new
        {
            ToDate = DateTime.Now.ToString("yyyy-MM-dd"),
            FromDate = DateTime.Now.ToString("yyyy-MM-dd"),
            CompareOnly = ""
        };
        _broker.Produce(message);
        //var broker = new BrokerService(new Broker
        //{
        //    BrokerAddress = "amqp://guest:guest@localhost:5672",
        //    BrokerQueue = "Directory_test"
        //});
        
      //  return broker.Produce(message);
        throw new NotImplementedException();
    }
}
