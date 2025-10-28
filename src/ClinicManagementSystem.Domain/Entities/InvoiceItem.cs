using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class InvoiceItem : BaseEntity
{
    [Required]
    public Guid InvoiceId { get; set; }
    [ForeignKey("InvoiceId")]
    public virtual Invoice? Invoice { get; set; }


    public Guid? ServiceCatalogId { get; set; }
    [ForeignKey("ServiceCatalogId")]
    public virtual ServiceCatalog? Service { get; set; }


    [MaxLength(200)]
    public string? ServiceName { get; set; }


    public int Quantity { get; set; } = 1;


    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }


    public bool RequiresPreauth { get; set; } = false;


    [Column(TypeName = "decimal(18,2)")]
    public decimal LineTotal { get; set; }
}