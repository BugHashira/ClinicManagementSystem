using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;
public class Wallet : BaseEntity
{
    [Required]
    public Guid PatientId { get; set; }


    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal Balance { get; set; } = 0m;


    [MaxLength(10)]
    public string? Currency { get; set; }


    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;


    public virtual ICollection<WalletTransaction>? Transactions { get; set; }
}
