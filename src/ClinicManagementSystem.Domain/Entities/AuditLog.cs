using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Entities;

public class AuditLog : BaseEntity
{
    [MaxLength(100)]
    public string? EntityType { get; set; }


    public Guid? EntityId { get; set; }


    [MaxLength(50)]
    public string? Action { get; set; }


    public string? OldValue { get; set; }
    public string? NewValue { get; set; }


    [MaxLength(100)]
    public string? PerformedBy { get; set; }


    public DateTime PerformedAt { get; set; } = DateTime.UtcNow;


    public string? IpAddress { get; set; }
    public string? DeviceInfo { get; set; }
}