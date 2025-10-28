using ClinicManagementSystem.API.Services.Interfaces;
using ClinicManagementSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    // GET: api/patients
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var patients = await _patientService.GetAllAsync();
        return Ok(patients);
    }

    // GET: api/patients/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var patient = await _patientService.GetByIdAsync(id);
        if (patient == null) return NotFound();
        return Ok(patient);
    }

    // POST: api/patients
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PatientCreateDto dto)
    {
        var created = await _patientService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/patients/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PatientUpdateDto dto)
    {
        var updated = await _patientService.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    // DELETE: api/patients/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _patientService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
