using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples.Application.Interfaces;

public interface IEmailService
{
    void Send(Email email);
}
