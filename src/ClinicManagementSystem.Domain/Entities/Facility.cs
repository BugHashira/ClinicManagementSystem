using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Entities;

public class Facility : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;


    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? TimeZone { get; set; }
    public string? Currency { get; set; }


    public virtual ICollection<Clinic>? Clinics { get; set; }
    public virtual ICollection<Patient>? Patients { get; set; }
}