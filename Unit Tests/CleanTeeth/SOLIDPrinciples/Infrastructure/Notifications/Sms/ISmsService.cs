using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Infrastructure.Notifications.Sms;

public interface ISmsService
{
    void Send(Patient patient, string message);
}
