using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;

namespace SOLIDPrinciples.Application.Services;

public class AppointmentService
{
    private List<Appointment> _appointments = new List<Appointment>();
    
    private readonly IAppointmentRepository _repository;   
    private readonly IEnumerable<INotificationService> _notifications;

    // Inyección de dependencias por constructor
    public AppointmentService(
        IAppointmentRepository repository, 
        IEnumerable<INotificationService> notifications
    )
    {
        _repository = repository;
        _notifications = notifications;
    }



    public void Schedule(Appointment appointment, Email patientEmail, Patient patient)
    {
        Console.WriteLine("Programar cita...");

        // VALIDACIÓN REGLA DE NEGOCIO: Verificar que el dentista no tenga otra cita en el mismo horario
        if (
            _appointments.Any(a =>
                a.DentistId == appointment.DentistId
                && a.TimeInterval.Start == appointment.TimeInterval.Start
            )
        )
        {
            Console.WriteLine("El dentista está ocupadO en ese momento.");
            return;
        }

        // AGREGAR LA CITA AL LISTADO DE CITAS
        _appointments.Add(appointment);

        // GUARDAR EN ARCHIVO
        _repository.Save(appointment);     

        // ENVIAR LA/LAS NOTIFICACIONES
        foreach (var notification in _notifications)
        {
            notification.Send(patient, "Cita programada");
        }

        // VISUALIZAR MENSAJE DE CONFIRMACIÓN
        Console.WriteLine("Cita programada con éxito.");
    }
}
