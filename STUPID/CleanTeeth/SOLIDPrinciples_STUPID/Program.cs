using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;

namespace SOLIDPrinciples_STUPID;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║  PRINCIPIOS SOLID                                          ║");
        Console.WriteLine("║  CÓDIGO CON ANTIPATRONES (STUPID)                          ║");
        Console.WriteLine("║  Sistema CleanTeeth                                        ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
        
        // Crear Email del paciente
        Email patientEmail = new Email("johndoe@email.com");

        // Crear paciente
        Patient patient = new Patient("John Doe", patientEmail);

        // Crear Email del dentista
        Email dentistEmail = new Email("dentist@gmail.com");

        // Crear dentista
        Dentist dentist = new Dentist("Dr. Smith", dentistEmail);

        // Crear consultorio
        DentalOffice dentalOffice = new DentalOffice("Consultorio de limpieza dental");

        // Crear intervalo de tiempo
        TimeInterval timeInterval = new TimeInterval(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        // Crear cita (Appointment)
        Appointment appointment = new Appointment(
            patient.Id,
            dentist.Id,
            dentalOffice.Id,
            timeInterval
        );

        // Crear el servicio de citas
        AppointmentService appointmentService = new AppointmentService();

        // Agendar la cita
        appointmentService.Schedule(appointment, patientEmail);

        Console.ReadLine();
    }
}