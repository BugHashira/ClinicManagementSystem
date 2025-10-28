using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class InsurancePolicy : BaseEntity
{
    [Required]
    public Guid PatientId { get; set; }


    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }


    [MaxLength(200)]
    public string? Insurer { get; set; }


    [MaxLength(200)]
    public string? PlanName { get; set; }


    [MaxLength(200)]
    public string? MemberId { get; set; }


    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }


    public bool IsActive { get; set; } = true; // derived based on dates
}