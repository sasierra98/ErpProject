using ErpProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ErpProject;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.HasKey(c => c.CategoryId);
            category.Property(c => c.Name).HasMaxLength(255);
            category.Property(c => c.IsActive);
            category.Property(c => c.CreatedAt);
            category.Property(c => c.UpdatedAt);
        });
    }
}