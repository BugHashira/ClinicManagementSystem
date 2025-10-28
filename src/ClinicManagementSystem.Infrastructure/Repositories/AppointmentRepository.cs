using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Infrastructure.Context;
using ClinicManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Infrastructure.Repositories;

public class AppointmentRepository(ApplicationDbContext context) : GenericRepository<Appointment>(context), IAppointmentRepository
{
    public async Task<IEnumerable<Appointment>> GetByClinicAsync(Guid clinicId)
    {
        return await _dbSet
            .Include(a => a.Patient)
            .Include(a => a.Clinic)
            .Where(a => a.ClinicId == clinicId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Appointment>> GetByPatientAsync(Guid patientId)
    {
        return await _dbSet
            .Include(a => a.Clinic)
            .Where(a => a.PatientId == patientId)
            .ToListAsync();
    }
}