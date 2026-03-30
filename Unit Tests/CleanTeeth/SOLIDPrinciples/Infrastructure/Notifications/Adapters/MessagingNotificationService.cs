using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Messaging;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

public class MessagingNotificationService : INotificationService
{
    private readonly IMessagingService _messagingService;

    // Inyección de dependencias por constructor
    public MessagingNotificationService(IMessagingService messagingService)
    {
        _messagingService = messagingService;
    }

    public void Send(Patient patient, string message)
    {
        _messagingService.Send(patient, message);
    }
}
