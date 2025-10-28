using ClinicManagementSystem.Application.DTOs;

namespace ClinicManagementSystem.API.Services.Interfaces;

public interface IPatientService
{
    Task<PatientReadDto> CreateAsync(PatientCreateDto dto);
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<PatientReadDto>> GetAllAsync();
    Task<PatientReadDto?> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(Guid id, PatientUpdateDto dto);
}
