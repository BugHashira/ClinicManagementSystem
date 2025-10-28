using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Infrastructure.Interfaces;

public interface IPatientRepository : IGenericRepository<Patient>
{
    Task<Patient?> GetByPhoneAsync(string phone);
    Task<Patient?> GetByFullNameAsync(string firstName, string lastName);
}