using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Application.Interfaces;

public interface INotificationService
{
    void Send(Patient patient, string message);
}
