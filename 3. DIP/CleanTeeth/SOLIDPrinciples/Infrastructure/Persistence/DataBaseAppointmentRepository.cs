using CleanTeeth.Domain.Entities;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Infrastructure.Persistence;

public class DataBaseAppointmentRepository : IAppointmentRepository
{
    public void Save(Appointment appointment)
    {
        // Lógica para guardar...
        Console.WriteLine($"Cita con el código: {appointment.Id} guardada en la Base de Datos");
    }
}
