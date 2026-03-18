using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Sms;

// Para cubrir el nuevo requerimiento de envio de SMS al cliente
public class TwilioSmsService : ISmsService
{
    public void Send(Patient patient)
    {
        // Lógica de envio...
        Console.WriteLine($"SMS enviado con Twilio para: {patient.Name}");
    }
}
