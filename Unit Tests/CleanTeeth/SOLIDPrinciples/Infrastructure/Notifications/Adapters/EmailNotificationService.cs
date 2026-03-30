using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Emails;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

public class EmailNotificationService : INotificationService
{
    private readonly IEmailService _emailService;

    // Inyección de dependencias
    public EmailNotificationService(IEmailService emailService)
    {
        _emailService = emailService;
    }
    
    public void Send(Patient patient, string message)
    {
        _emailService.Send(patient.Email, message);
    }
}
