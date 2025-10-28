using ClinicManagementSystem.API.Services.Interfaces;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Infrastructure.Interfaces;

namespace ClinicManagementSystem.API.Services;

public class PatientService(IPatientRepository patientRepo) : IPatientService
{
    public async Task<IEnumerable<PatientReadDto>> GetAllAsync()
    {
        var patients = await patientRepo.GetAllAsync();
        return patients.Select(MapToReadDto);
    }

    public async Task<PatientReadDto?> GetByIdAsync(Guid id)
    {
        var patient = await patientRepo.GetByIdAsync(id);
        return patient == null ? null : MapToReadDto(patient);
    }

    public async Task<PatientReadDto> CreateAsync(PatientCreateDto dto)
    {
        var (firstName, lastName) = SplitFullName(dto.FullName);

        var patient = new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dto.DateOfBirth,
            PhoneNumber = dto.ContactNumber,
            Email = dto.Email,
            ContactAddress = dto.Address
        };

        await patientRepo.AddAsync(patient);
        await patientRepo.SaveChangesAsync();

        return MapToReadDto(patient);
    }

    public async Task<bool> UpdateAsync(Guid id, PatientUpdateDto dto)
    {
        var patient = await patientRepo.GetByIdAsync(id);
        if (patient == null) return false;

        var (firstName, lastName) = SplitFullName(dto.FullName);

        patient.FirstName = firstName;
        patient.LastName = lastName;
        patient.DateOfBirth = dto.DateOfBirth;
        patient.PhoneNumber = dto.ContactNumber;
        patient.Email = dto.Email;
        patient.ContactAddress = dto.Address;

        patientRepo.Update(patient);
        await patientRepo.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var patient = await patientRepo.GetByIdAsync(id);
        if (patient == null) return false;

        patientRepo.Delete(patient);
        await patientRepo.SaveChangesAsync();

        return true;
    }

    private static PatientReadDto MapToReadDto(Patient p)
    {
        return new PatientReadDto
        {
            Id = p.Id,
            FullName = $"{(p.FirstName ?? string.Empty)} {(p.LastName ?? string.Empty)}".Trim(),
            DateOfBirth = p.DateOfBirth ?? DateTime.MinValue,
            ContactNumber = p.PhoneNumber ?? string.Empty,
            Email = p.Email ?? string.Empty,
            Address = p.ContactAddress ?? string.Empty
        };
    }

    private static (string firstName, string lastName) SplitFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName)) return (string.Empty, string.Empty);
        var parts = fullName.Trim().Split(' ', 2);
        return parts.Length == 1 ? (parts[0], string.Empty) : (parts[0], parts[1]);
    }
}