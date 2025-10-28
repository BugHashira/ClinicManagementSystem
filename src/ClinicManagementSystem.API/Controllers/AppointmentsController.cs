using ClinicManagementSystem.API.Services.Interfaces;
using ClinicManagementSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController(IAppointmentService appointmentService) : ControllerBase
{

    // GET: api/appointments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentReadDto>>> GetAll()
    {
        var appointments = await appointmentService.GetAllAsync();
        return Ok(appointments);
    }

    // GET: api/appointments/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AppointmentReadDto>> GetById(Guid id)
    {
        var appointment = await appointmentService.GetByIdAsync(id);
        if (appointment == null) return NotFound();
        return Ok(appointment);
    }

    // POST: api/appointments
    [HttpPost]
    public async Task<ActionResult<AppointmentReadDto>> Create([FromBody] AppointmentCreateDto dto)
    {
        var created = await appointmentService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/appointments/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] AppointmentUpdateDto dto)
    {
        var updated = await appointmentService.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    // DELETE: api/appointments/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await appointmentService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
