using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class Clinic : BaseEntity
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;


    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;


    [ForeignKey("FacilityId")]
    public virtual Facility? Facility { get; set; }


    public virtual ICollection<Appointment>? Appointments { get; set; }
}