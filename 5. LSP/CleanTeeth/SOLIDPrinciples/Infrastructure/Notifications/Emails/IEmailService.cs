using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

public interface IEmailService
{
    void Send(Email email);
}
