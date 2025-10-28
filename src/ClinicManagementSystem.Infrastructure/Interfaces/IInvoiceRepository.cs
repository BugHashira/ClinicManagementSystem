using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Infrastructure.Interfaces;

public interface IInvoiceRepository : IGenericRepository<Invoice>
{
    Task<Invoice?> GetInvoiceWithItemsAsync(Guid invoiceId);
    Task<IEnumerable<Invoice>> GetByPatientAsync(Guid patientId);
}
