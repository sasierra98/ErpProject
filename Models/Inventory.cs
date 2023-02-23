using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ErpProject.Models;

public class Inventory
{
    [Key] 
    public long InventoryId { get; set; }

    [Required] [NotNull] [MaxLength(250)] 
    public string? Name { get; set; }
    
    [AllowNull]
    public string Description { get; set; }

    [Required] 
    public int Quantity { get; set; }

    [Required] 
    public bool IsActive { get; set; }

    [Required] 
    public DateTime CreatedAt { get; set; }
    
    [Required] 
    public DateTime UpdatedAt { get; set; }
    
    [ForeignKey("Category")]
    public long CategoryId { get; set; }
    
    [ForeignKey("Product")]
    public long ProductId { get; set; }
}