using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Infrastructure.Context;
using ClinicManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Infrastructure.Repositories;
public class PatientRepository(ApplicationDbContext context) : GenericRepository<Patient>(context), IPatientRepository
{
    public async Task<Patient?> GetByPhoneAsync(string phone)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.PhoneNumber == phone);
    }

    public async Task<Patient?> GetByFullNameAsync(string firstName, string lastName)
    {
        return await _dbSet.FirstOrDefaultAsync(p =>
            p.FirstName == firstName && p.LastName == lastName);
    }
}