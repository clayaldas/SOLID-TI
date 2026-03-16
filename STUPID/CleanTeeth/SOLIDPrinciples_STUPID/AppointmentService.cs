using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDPrinciples_STUPID;

public class AppointmentService
{
    private List<Appointment> _appointments = new List<Appointment>();

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
        File.AppendAllText("appointments.txt", appointment.Id + Environment.NewLine);

        // ENVIAR CORREO ELECTRÓNICO AL PACIENTE
        Console.WriteLine("Enviando correo electrónico a: " + patientEmail.Value);

        // VISUALIZAR MENSAJE DE CONFIRMACIÓN
        Console.WriteLine("Cita programada con éxito.");
    }
}

