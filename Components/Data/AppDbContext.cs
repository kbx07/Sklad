using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sklad.Components.Models;

namespace Sklad.Components.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tool> Tool { get; set; }
    public DbSet<Location> Location { get; set; }
    public DbSet<Condition> Condition { get; set; }
    public DbSet<ExactLocation> ExactLocation { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         /*modelBuilder.Entity<Tool>(entity =>
        {
            entity.ToTable("tool"); 
            entity.Property(e => e.LocationId)
                .HasColumnName("location_id");
            
            entity.Property(e => e.ConditionId)
                .HasColumnName("condition_id");
            
            entity.Property(e => e.ExactLocationId)
                .HasColumnName("exactlocation_id");
        });
        */

         
        
        
        
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