using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ErpProject.Models;

public class Product
{
    [Key] 
    public long ProductId { get; set; }
    
    [Required] [MaxLength(255)]
    public string? Name { get; set; }
    
    [AllowNull]
    public string? Description { get; set; }
    
    [Required] 
    public bool IsActive { get; set; }

    [Required] 
    public DateTime CreatedAt { get; set; }
    
    [Required] 
    public DateTime UpdatedAt { get; set; }
    
    [ForeignKey("Category")]
    public long CategoryId { get; set; }
}