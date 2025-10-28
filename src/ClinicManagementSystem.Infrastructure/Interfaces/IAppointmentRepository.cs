using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Infrastructure.Interfaces;

public interface IAppointmentRepository : IGenericRepository<Appointment>
{
    Task<IEnumerable<Appointment>> GetByClinicAsync(Guid clinicId);
    Task<IEnumerable<Appointment>> GetByPatientAsync(Guid patientId);
}
