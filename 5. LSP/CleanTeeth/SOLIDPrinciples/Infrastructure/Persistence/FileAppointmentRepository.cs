using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Persistence;

public class FileAppointmentRepository : IAppointmentRepository
{
    public void Save(Appointment appointment)
    {
        // Lógica para guardar...
        File.AppendAllText("appointments.txt", appointment.Id + Environment.NewLine);
    }
}
