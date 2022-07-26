
using Internal.Audit.Application.Models;

public interface IBrokerService
{
    MQResponse Produce(object message);
}

