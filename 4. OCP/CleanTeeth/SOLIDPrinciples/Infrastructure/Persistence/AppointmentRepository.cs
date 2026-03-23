using CleanTeeth.Domain.Entities;

namespace SOLIDPrinciples.Infrastructure.Persistence;

public class AppointmentRepository
{
    public void Save(Appointment appointment)
    {
        File.AppendAllText("appointments.txt", appointment.Id + Environment.NewLine);
    }
}
