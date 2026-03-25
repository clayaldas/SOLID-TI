using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.TeamMessaging;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

public class TeamMessagingNotificationService : INotificationService
{
    private readonly ITeamMessagingService _teamMessagingService;

    public TeamMessagingNotificationService(ITeamMessagingService teamMessagingService)
    {
        _teamMessagingService = teamMessagingService;
    }    
    public void Send(Patient patient, string message)
    {
        _teamMessagingService.Send(patient);
    }
}
