using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagementSystem.Domain.Entities;

public class ServiceCatalog : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;


    public string? Category { get; set; }


    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }


    public bool IsActive { get; set; } = true;
}