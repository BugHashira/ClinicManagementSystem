using ClinicManagementSystem.Application.DTOs;

namespace ClinicManagementSystem.API.Services.Interfaces;
public interface IInvoiceService
{
    Task<IEnumerable<InvoiceReadDto>> GetAllAsync();
    Task<InvoiceReadDto?> GetByIdAsync(Guid id);
    Task<InvoiceReadDto> CreateAsync(InvoiceCreateDto dto);
    Task<bool> UpdateAsync(Guid id, InvoiceUpdateDto dto);
    Task<bool> DeleteAsync(Guid id);
}