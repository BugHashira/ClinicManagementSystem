using ClinicManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class Appointment : BaseEntity
{
    [Required]
    public Guid PatientId { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }


    [Required]
    public Guid ClinicId { get; set; }
    [ForeignKey("ClinicId")]
    public virtual Clinic? Clinic { get; set; }


    public Guid? AppointmentTypeId { get; set; }
    [ForeignKey("AppointmentTypeId")]
    public virtual AppointmentType? AppointmentType { get; set; }


    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int DurationMinutes { get; set; }


    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;


    public Guid? InvoiceId { get; set; }
    [ForeignKey("InvoiceId")]
    public virtual Invoice? Invoice { get; set; }
}
