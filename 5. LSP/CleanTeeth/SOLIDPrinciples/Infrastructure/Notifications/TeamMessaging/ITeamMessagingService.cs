using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Infrastructure.Notifications.TeamMessaging;

public interface ITeamMessagingService
{
    void Send(Patient patient);
}
