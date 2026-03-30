using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

public class SendGridEmailService : IEmailService
{   

    public void Send(Email email, string message)
    {
        // Lógica de envio...
        Console.WriteLine($"SendGrid Email enviado para: {email.Value}");
        Console.WriteLine($"Notificación:{message}");
    }
}
