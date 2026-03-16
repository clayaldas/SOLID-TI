using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

// Envio de correos por SMTP
public class SmtpEmailService : IEmailService
{
    public void Send(Email email)
    {
        // Lógica de envio...
        Console.WriteLine($"Email enviado para: {email.Value}");
    }
}
