using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Application.Interfaces;

public interface IAppointmentRepository
{
    void Save(Appointment appointment);
}
