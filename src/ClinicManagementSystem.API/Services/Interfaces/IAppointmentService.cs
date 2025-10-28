using ClinicManagementSystem.Application.DTOs;

namespace ClinicManagementSystem.API.Services.Interfaces;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentReadDto>> GetAllAsync();
    Task<AppointmentReadDto?> GetByIdAsync(Guid id);
    Task<AppointmentReadDto> CreateAsync(AppointmentCreateDto dto);
    Task<bool> UpdateAsync(Guid id, AppointmentUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
}