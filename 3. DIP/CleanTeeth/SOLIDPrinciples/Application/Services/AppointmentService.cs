using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications;
using SOLIDPrinciples.Infrastructure.Persistence;

namespace SOLIDPrinciples.Application.Services;

public class AppointmentService
{
    private List<Appointment> _appointments = new List<Appointment>();

    //private readonly AppointmentRepository _repository; //MODIFICADO
    private readonly IAppointmentRepository _repository;//NUEVO

    private readonly IEmailService _emailService; 
    private readonly ISmsService _smsService;

    //MODIFICADO
    //public AppointmentService(
    //    AppointmentRepository repository,
    //    IEmailService emailService,
    //    ISmsService smsService
    //)
    //{
    //    _repository = repository;
    //    _emailService = emailService;
    //    _smsService = smsService;
    //}

    //NUEVO
    public AppointmentService(
        IAppointmentRepository repository,
        IEmailService emailService,
        ISmsService smsService
    )
    {
        _repository = repository;
        _emailService = emailService;
        _smsService = smsService;
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

        // ENVIAR CORREO ELECTRÓNICO AL PACIENTE        
        _emailService.Send(patientEmail); 

        // NOTA: Esto es para cumbrir el nuevo requerimiento
        // Enviar las notificaciones por SMS
        // ENVIAR NOTIFICACIÓN POR SMS
        _smsService.Send(patient);

        // VISUALIZAR MENSAJE DE CONFIRMACIÓN
        Console.WriteLine("Cita programada con éxito.");
    }
}
