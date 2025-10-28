using ClinicManagementSystem.API.Services.Interfaces;
using ClinicManagementSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoicesController(IInvoiceService invoiceService) : ControllerBase
{

    // GET: api/invoices
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InvoiceReadDto>>> GetAll()
    {
        var invoices = await invoiceService.GetAllAsync();
        return Ok(invoices);
    }

    // GET: api/invoices/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<InvoiceReadDto>> GetById(Guid id)
    {
        var invoice = await invoiceService.GetByIdAsync(id);
        if (invoice == null) return NotFound();
        return Ok(invoice);
    }

    // POST: api/invoices
    [HttpPost]
    public async Task<ActionResult<InvoiceReadDto>> Create([FromBody] InvoiceCreateDto dto)
    {
        var created = await invoiceService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/invoices/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] InvoiceUpdateDto dto)
    {
        var updated = await invoiceService.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    // DELETE: api/invoices/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await invoiceService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
