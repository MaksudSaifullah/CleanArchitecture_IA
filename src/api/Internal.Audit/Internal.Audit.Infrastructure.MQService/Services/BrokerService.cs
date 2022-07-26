using Internal.Audit.Application.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Internal.Audit.Infrastructure.MQService.Services;

public class BrokerService : IBrokerService
{
    public IModel _channel = null;
   // private readonly Broker _config;
    public BrokerService(string BrokerAddress)
    {
        //_config = config;
        var factory = new ConnectionFactory
        {
            Uri = new Uri(BrokerAddress)
        };
        var con = factory.CreateConnection();
        if (_channel == null)
            _channel = con.CreateModel();
    }
    public MQResponse Produce(object message,string brokerQueue)
    {
        try
        {
            _channel.QueueDeclare(brokerQueue, durable: true, exclusive: false, autoDelete: false, arguments: null);

            if (message == null)
                return new MQResponse
                {
                    Success = false,
                    Message = "invalid message request"
                };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _channel.BasicPublish("", brokerQueue, null, body);
            return new MQResponse
            {
                Success = true,
                Message = "Request Successful"
            };
        }
        catch (Exception e)
        {
            return new MQResponse
            {
                Success = false,
                Message = e.Message
            };
        }
    }
}
