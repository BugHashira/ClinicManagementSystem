using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Entities;

public class AppointmentType : BaseEntity
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;


    public int DefaultDurationMinutes { get; set; } = 60;
}