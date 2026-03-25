using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Infrastructure.Notifications.Messaging;

public class WhatsAppMessagingService : IMessagingService
{
    public void Send(Patient patient)
    {
        // Lógica de envio...
        Console.WriteLine($"Mensaje  enviado con WhatsApp para: {patient.Name}");
    }
}
