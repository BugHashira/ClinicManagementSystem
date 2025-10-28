using ClinicManagementSystem.API.Services.Interfaces;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Infrastructure.Interfaces;

namespace ClinicManagementSystem.API.Services;

public class AppointmentService(IAppointmentRepository appointmentRepo, IPatientRepository patientRepo) : IAppointmentService
{
    public async Task<IEnumerable<AppointmentReadDto>> GetAllAsync()
    {
        var appointments = await appointmentRepo.GetAllAsync();
        var result = new List<AppointmentReadDto>();

        foreach (var a in appointments)
        {
            var patientName = await ResolvePatientNameAsync(a.PatientId);
            result.Add(new AppointmentReadDto
            {
                Id = a.Id,
                PatientId = a.PatientId,
                PatientName = patientName,
                AppointmentDate = a.Date,
                Reason = string.Empty,
                DoctorName = string.Empty
            });
        }

        return result;
    }

    public async Task<AppointmentReadDto?> GetByIdAsync(Guid id)
    {
        var a = await appointmentRepo.GetByIdAsync(id);
        if (a == null) return null;

        var patientName = await ResolvePatientNameAsync(a.PatientId);

        return new AppointmentReadDto
        {
            Id = a.Id,
            PatientId = a.PatientId,
            PatientName = patientName,
            AppointmentDate = a.Date,
            Reason = string.Empty,
            DoctorName = string.Empty
        };
    }

    public async Task<AppointmentReadDto> CreateAsync(AppointmentCreateDto dto)
    {
        var appointment = new Appointment
        {
            Id = Guid.NewGuid(),
            PatientId = dto.PatientId,
            Date = dto.AppointmentDate.Date,
            StartTime = dto.AppointmentDate.TimeOfDay,
            EndTime = dto.AppointmentDate.TimeOfDay.Add(TimeSpan.FromMinutes(30)),
            DurationMinutes = 30
        };

        await appointmentRepo.AddAsync(appointment);
        await appointmentRepo.SaveChangesAsync();

        var patientName = await ResolvePatientNameAsync(appointment.PatientId);

        return new AppointmentReadDto
        {
            Id = appointment.Id,
            PatientId = appointment.PatientId,
            PatientName = patientName,
            AppointmentDate = appointment.Date,
            Reason = string.Empty,
            DoctorName = string.Empty
        };
    }

    public async Task<bool> UpdateAsync(Guid id, AppointmentUpdateDto dto)
    {
        var appointment = await appointmentRepo.GetByIdAsync(id);
        if (appointment == null) return false;

        appointment.Date = dto.AppointmentDate.Date;
        appointment.StartTime = dto.AppointmentDate.TimeOfDay;
        appointment.EndTime = dto.AppointmentDate.TimeOfDay.Add(TimeSpan.FromMinutes(30));
        appointment.DurationMinutes = (int)(appointment.EndTime - appointment.StartTime).TotalMinutes;

        appointmentRepo.Update(appointment);
        await appointmentRepo.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var appointment = await appointmentRepo.GetByIdAsync(id);
        if (appointment == null) return false;

        appointmentRepo.Delete(appointment);
        await appointmentRepo.SaveChangesAsync();
        return true;
    }

    private async Task<string> ResolvePatientNameAsync(Guid patientId)
    {
        if (patientId == Guid.Empty) return string.Empty;
        var p = await patientRepo.GetByIdAsync(patientId);
        if (p == null) return string.Empty;
        return $"{(p.FirstName ?? string.Empty)} {(p.LastName ?? string.Empty)}".Trim();
    }
}