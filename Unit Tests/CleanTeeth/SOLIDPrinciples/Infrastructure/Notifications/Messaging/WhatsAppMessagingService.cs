using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Infrastructure.Notifications.Messaging;

public class WhatsAppMessagingService : IMessagingService
{    
    public void Send(Patient patient, string message)
    {
        // Lógica de envio...
        Console.WriteLine($"Mensaje  enviado con WhatsApp para: {patient.Name}");
        Console.WriteLine($"Notificación:{message}");
    }
}
