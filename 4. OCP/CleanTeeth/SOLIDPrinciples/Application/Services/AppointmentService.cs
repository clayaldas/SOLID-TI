using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using SOLIDPrinciples.Application.Interfaces;
using SOLIDPrinciples.Infrastructure.Notifications.Emails;
using SOLIDPrinciples.Infrastructure.Notifications.Messaging;
using SOLIDPrinciples.Infrastructure.Notifications.Sms;

namespace SOLIDPrinciples.Application.Services;

public class AppointmentService
{
    private List<Appointment> _appointments = new List<Appointment>();
    
    private readonly IAppointmentRepository _repository;

    //private readonly IEmailService _emailService;//MODIFICADO
    //private readonly ISmsService _smsService;  //MODIFICADO  
    //private readonly IMessagingService _messagingService;//MODIFICADO
    private readonly IEnumerable<INotificationService> _notifications;//NUEVO


    //MODIFICADO
    //public AppointmentService(
    //    IAppointmentRepository repository,
    //    IEmailService emailService,
    //    ISmsService smsService, IMessagingService messagingService
    //)
    //{
    //    _repository = repository;
    //    _emailService = emailService;
    //    _smsService = smsService;

    //    _messagingService = messagingService;
    //}

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


        // MODIFICADO
        // ENVIAR CORREO ELECTRÓNICO AL PACIENTE        
        //_emailService.Send(patientEmail);        
        //_messagingService.Send(patient);
        // NOTA: Esto es para cumbrir el nuevo requerimiento
        // Enviar las notificaciones por SMS
        // ENVIAR NOTIFICACIÓN POR SMS
        //_smsService.Send(patient);

        // NUEVO
        foreach (var notification in _notifications)
        {
            notification.Send(patient, "Cita programada");
        }

        // VISUALIZAR MENSAJE DE CONFIRMACIÓN
        Console.WriteLine("Cita programada con éxito.");
    }
}
