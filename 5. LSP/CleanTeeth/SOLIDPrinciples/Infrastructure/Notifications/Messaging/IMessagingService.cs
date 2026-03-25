using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Infrastructure.Notifications.Messaging;

public interface IMessagingService
{
    void Send(Patient patient);
}
