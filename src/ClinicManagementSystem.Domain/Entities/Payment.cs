using ClinicManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class Payment : BaseEntity
{
    [Required]
    public Guid InvoiceId { get; set; }
    [ForeignKey("InvoiceId")]
    public virtual Invoice? Invoice { get; set; }


    public Guid? WalletId { get; set; }
    [ForeignKey("WalletId")]
    public virtual Wallet? Wallet { get; set; }


    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;


    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }


    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;


    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;


    [MaxLength(200)]
    public string? Reference { get; set; }
}