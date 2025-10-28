using ClinicManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class Invoice : BaseEntity
{
    [Required]
    public Guid PatientId { get; set; }
    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }


    public Guid? AppointmentId { get; set; }
    [ForeignKey("AppointmentId")]
    public virtual Appointment? Appointment { get; set; }


    [MaxLength(100)]
    public string? InvoiceNumber { get; set; }


    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;


    [Column(TypeName = "decimal(18,2)")]
    public decimal SubTotal { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal DiscountTotal { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal GrandTotal { get; set; }


    [MaxLength(10)]
    public string? Currency { get; set; }


    public virtual ICollection<InvoiceItem>? Items { get; set; }
    public virtual ICollection<Payment>? Payments { get; set; }
}