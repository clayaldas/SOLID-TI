using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples.Infrastructure.Notifications;

public class EmailNotificationService
{
    public void Send(Email emailPatient)
    {
        Console.WriteLine($"Email enviado para: {emailPatient.Value}");
    }
}
