using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Application.Interfaces;

public interface ISmsService
{
    void Send(Patient patient);
}
