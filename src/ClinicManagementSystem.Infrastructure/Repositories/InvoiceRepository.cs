using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Infrastructure.Context;
using ClinicManagementSystem.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Infrastructure.Repositories;
public class InvoiceRepository(ApplicationDbContext context) : GenericRepository<Invoice>(context), IInvoiceRepository
{
    public async Task<Invoice?> GetInvoiceWithItemsAsync(Guid invoiceId)
    {
        return await _dbSet
            .Include(i => i.Items)
            .Include(i => i.Payments)
            .FirstOrDefaultAsync(i => i.Id == invoiceId);
    }

    public async Task<IEnumerable<Invoice>> GetByPatientAsync(Guid patientId)
    {
        return await _dbSet
            .Include(i => i.Items)
            .Where(i => i.PatientId == patientId)
            .ToListAsync();
    }
}