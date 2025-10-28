using ClinicManagementSystem.API.Services.Interfaces;
using ClinicManagementSystem.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController(IPatientService patientService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var patientDtos = await patientService.GetAllAsync();
        return Ok(patientDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var patientDto = await patientService.GetByIdAsync(id);
        if (patientDto == null) return NotFound();
        return Ok(patientDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PatientCreateDto dto)
    {
        var created = await patientService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, PatientUpdateDto dto)
    {
        var updated = await patientService.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await patientService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}