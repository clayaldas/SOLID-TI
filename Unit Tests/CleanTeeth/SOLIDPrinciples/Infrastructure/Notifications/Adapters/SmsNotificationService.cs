using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Sms;

namespace SOLIDPrinciples.Infrastructure.Notifications.Adapters;

public class SmsNotificationService : INotificationService
{
    private readonly ISmsService _smsService;

    // Inyección de dependencias por el constructor
    public SmsNotificationService(ISmsService smsService)
    {
        _smsService = smsService;
    }
    public void Send(Patient patient, string message)
    {
        _smsService.Send(patient, message);
    }
}
