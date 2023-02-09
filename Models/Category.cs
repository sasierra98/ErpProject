using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ErpProject.Models;

public class Category
{
    public long CategoryId { get; set; }
    public string? Name { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}