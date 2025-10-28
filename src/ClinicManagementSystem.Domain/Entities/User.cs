using ClinicManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(150)]
    public string UserName { get; set; } = null!;


    [MaxLength(200)]
    public string? FullName { get; set; }


    [MaxLength(200)]
    public string? Email { get; set; }


    [Required]
    public Role Role { get; set; } = Role.FrontDesk;


    public bool IsActive { get; set; } = true;


    // Password and authentication fields should be handled by Identity or auth service
    public virtual ICollection<AuditLog>? AuditLogs { get; set; }
}