using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples.Infrastructure.Notifications.Sms;

// Para cubrir el nuevo requerimiento de envio de SMS al cliente
public class TwilioSmsService : ISmsService
{
    public void Send(Patient patient, string message)
    {
        // Lógica de envio...
        Console.WriteLine($"SMS enviado con Twilio para: {patient.Name}");
        Console.WriteLine($"Notificación:{message}");
    }
}
