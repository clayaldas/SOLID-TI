using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Infrastructure.Notifications.TeamMessaging;

// Para enviar la notificación por: Discord
public class DiscordTeamMessaging : ITeamMessagingService
{   
    public void Send(Patient patient, string message)
    {
        // Lógica de envio...
        Console.WriteLine($"Mensaje  enviado con Discordd para: {patient.Name}");
        Console.WriteLine($"Notificación:{message}");
    }
}
