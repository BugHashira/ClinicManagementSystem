using ClinicManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class Patient : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string PatientCode { get; set; } = null!; // e.g. HOSP-00001


    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = null!;


    [MaxLength(100)]
    public string? MiddleName { get; set; }


    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = null!;


    public Gender Gender { get; set; }


    public DateTime? DateOfBirth { get; set; }


    [MaxLength(32)]
    public string? PhoneNumber { get; set; } // E.164 stored as string


    [MaxLength(200)]
    public string? Email { get; set; }


    public string? ContactAddress { get; set; }


    public string? PhotoUrl { get; set; }


    public bool HasInsurance { get; set; } = false;


    [Column(TypeName = "decimal(18,2)")]
    public decimal WalletBalance { get; set; } = 0m;


    public virtual Wallet? Wallet { get; set; }
    public virtual ICollection<PatientIdentity>? Identities { get; set; }
    public virtual ICollection<InsurancePolicy>? InsurancePolicies { get; set; }
    public virtual ICollection<Appointment>? Appointments { get; set; }
    public virtual ICollection<Invoice>? Invoices { get; set; }
}
