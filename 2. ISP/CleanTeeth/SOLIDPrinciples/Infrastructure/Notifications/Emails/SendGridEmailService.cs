using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Notifications.Emails;

public class SendGridEmailService : IEmailService
{
    public void Send(Email email)
    {
        // Lógica de envio...
        Console.WriteLine($"SendGrid Email enviado para: {email.Value}");
    }
}
