using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

internal class BrevoEmailService : IEmailService
{
    public void Send(Email email)
    {
        // Lógica de envio...
        Console.WriteLine($"Brevo Email enviado para: {email.Value}");
    }
}
