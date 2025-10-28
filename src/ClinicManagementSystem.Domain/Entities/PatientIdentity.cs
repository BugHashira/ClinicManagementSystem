using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class PatientIdentity : BaseEntity
{
    [Required]
    public Guid PatientId { get; set; }


    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }


    [Required]
    [MaxLength(100)]
    public string IdentityType { get; set; } = null!; // e.g., HospitalID, NationalID


    [Required]
    [MaxLength(200)]
    public string IdentityNumber { get; set; } = null!;


    public bool IsVerified { get; set; } = false;
}
