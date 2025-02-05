using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sklad.Components.Models;

namespace Sklad.Components.Data;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Tool> Tool { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tool>(entity =>
        {
            entity.ToTable("Tool"); 
            
        });
        
        base.OnModelCreating(modelBuilder);
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.ClrType.GetProperties()
                .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

            foreach (var property in properties)
            {
                var converter = new ValueConverter<DateTime, DateTime>(
                    v => v.ToUniversalTime(), 
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); 
                
                modelBuilder.Entity(entityType.ClrType)
                    .Property(property.Name)
                    .HasConversion(converter);
            }
        }
    }
}