using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Application.Services;
using SOLIDPrinciples.Infrastructure.Notifications.Adapters;
using SOLIDPrinciples.Infrastructure.Notifications.Emails;
using SOLIDPrinciples.Infrastructure.Notifications.Messaging;
using SOLIDPrinciples.Infrastructure.Notifications.Sms;
using SOLIDPrinciples.Infrastructure.Notifications.TeamMessaging;


//using SOLIDPrinciples.Infrastructure.Notifications.Messaging;
//using SOLIDPrinciples.Infrastructure.Notifications.Sms;
using SOLIDPrinciples.Infrastructure.Persistence;

namespace SOLIDPrinciples;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║  PRINCIPIOS SOLID                                                         ║");
        Console.WriteLine("║  PASO 5: LISKOV SUSTITUTION PINCIPLE - PRINCIPIO DE SUSTITUCIÓN DE LISKOV ║");
        Console.WriteLine("║  Sistema CleanTeeth - REFACTORIZADO                                       ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════╝\n");

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

        // Crear el repositorio de citas y el servicio de notificaciones        
        //DataBaseAppointmentRepository repository = new DataBaseAppointmentRepository();
        //FileAppointmentRepository repository = new FileAppointmentRepository();

        //IAppointmentRepository repository = new FileAppointmentRepository();
        IAppointmentRepository repository = new DataBaseAppointmentRepository();

        //NUEVO
        List <INotificationService> notifications = new List<INotificationService>();
        
        //NUEVO
        notifications.Add(new EmailNotificationService(new SmtpEmailService()));
        notifications.Add(new SmsNotificationService (new TwilioSmsService()));

        notifications.Add(new MessagingNotificationService(new WhatsAppMessagingService()));

        notifications.Add(new TeamMessagingNotificationService(new DiscordTeamMessaging()));
        
        //NUEVO
        AppointmentService appointmentService = new AppointmentService(repository,
           notifications);

        // Agendar la cita        
        appointmentService.Schedule(appointment, patientEmail, patient);

        Console.ReadLine();
    }
}