using ClinicManagementSystem.API.Services.Interfaces;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Infrastructure.Interfaces;
using System;

namespace ClinicManagementSystem.API.Services;

public class InvoiceService(IInvoiceRepository invoiceRepo, IPatientRepository patientRepo) : IInvoiceService
{
    public async Task<IEnumerable<InvoiceReadDto>> GetAllAsync()
    {
        var invoices = await invoiceRepo.GetAllAsync();
        var result = new List<InvoiceReadDto>();

        foreach (var inv in invoices)
        {
            var patientName = await ResolvePatientNameAsync(inv.PatientId);
            result.Add(new InvoiceReadDto
            {
                Id = inv.Id,
                PatientId = inv.PatientId,
                PatientName = patientName,
                Amount = inv.GrandTotal
            });
        }

        return result;
    }

    public async Task<InvoiceReadDto?> GetByIdAsync(Guid id)
    {
        var inv = await invoiceRepo.GetInvoiceWithItemsAsync(id) ?? await invoiceRepo.GetByIdAsync(id);
        if (inv == null) return null;

        var patientName = await ResolvePatientNameAsync(inv.PatientId);

        return new InvoiceReadDto
        {
            Id = inv.Id,
            PatientId = inv.PatientId,
            PatientName = patientName,
            Amount = inv.GrandTotal
        };
    }

    public async Task<InvoiceReadDto> CreateAsync(InvoiceCreateDto dto)
    {
        var invoice = new Invoice
        {
            Id = Guid.NewGuid(),
            PatientId = dto.PatientId,
            SubTotal = dto.Amount,
            DiscountTotal = 0m,
            GrandTotal = dto.Amount,
            InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N").Substring(0, 6)}",
        };

        await invoiceRepo.AddAsync(invoice);
        await invoiceRepo.SaveChangesAsync();

        var patientName = await ResolvePatientNameAsync(invoice.PatientId);

        return new InvoiceReadDto
        {
            Id = invoice.Id,
            PatientId = invoice.PatientId,
            PatientName = patientName,
            Amount = invoice.GrandTotal,
        };
    }

    public async Task<bool> UpdateAsync(Guid id, InvoiceUpdateDto dto)
    {
        var invoice = await invoiceRepo.GetByIdAsync(id);
        if (invoice == null) return false;

        // Map all updatable fields from the DTO
        invoice.SubTotal = dto.Amount;
        invoice.GrandTotal = dto.Amount;

        invoiceRepo.Update(invoice);
        await invoiceRepo.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var invoice = await invoiceRepo.GetByIdAsync(id);
        if (invoice == null) return false;

        invoiceRepo.Delete(invoice);
        await invoiceRepo.SaveChangesAsync();
        return true;
    }

    private async Task<string> ResolvePatientNameAsync(Guid patientId)
    {
        if (patientId == Guid.Empty) return string.Empty;
        var p = await patientRepo.GetByIdAsync(patientId);
        if (p == null) return string.Empty;
        return $"{(p.FirstName ?? string.Empty)} {(p.LastName ?? string.Empty)}".Trim();
    }
}