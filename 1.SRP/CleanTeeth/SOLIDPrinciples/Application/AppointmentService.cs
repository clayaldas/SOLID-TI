using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Infrastructure.Notifications;
using SOLIDPrinciples.Infrastructure.Persistence;

namespace SOLIDPrinciples.Application;

public class AppointmentService
{
    private List<Appointment> _appointments = new List<Appointment>();

    private readonly AppointmentRepository _repository;
    private readonly EmailNotificationService _notification;

    public AppointmentService(
        AppointmentRepository repository,
        EmailNotificationService notification
    )
    {
        _repository = repository;
        _notification = notification;
    }

    public void Schedule(Appointment appointment, Email patientEmail)
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

        // ENVIAR CORREO ELECTRÓNICO AL PACIENTE
        _notification.Send(patientEmail);

        // VISUALIZAR MENSAJE DE CONFIRMACIÓN
        Console.WriteLine("Cita programada con éxito.");
    }
}
