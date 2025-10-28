using ClinicManagementSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class WalletTransaction : BaseEntity
{
    [Required]
    public Guid WalletId { get; set; }


    [ForeignKey("WalletId")]
    public virtual Wallet? Wallet { get; set; }


    public TransactionType TransactionType { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal BalanceBefore { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal BalanceAfter { get; set; }


    public string? Reference { get; set; }
    public string? Description { get; set; }
}
