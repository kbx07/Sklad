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
    
    // Opcjonalnie: Możesz skonfigurować model w metodzie OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tool>(entity =>
        {
            entity.ToTable("Tool"); // Wymusza małe litery
            //entity.HasKey(e => e.Id); // Klucz główny
        });
        
        base.OnModelCreating(modelBuilder);

        // Iteracja przez wszystkie encje
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.ClrType.GetProperties()
                .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

            foreach (var property in properties)
            {
                var converter = new ValueConverter<DateTime, DateTime>(
                    v => v.ToUniversalTime(), // Konwersja podczas zapisu (do UTC)
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)); // Konwersja podczas odczytu (UTC)

                // Ustawienie konwersji na poziomie encji
                modelBuilder.Entity(entityType.ClrType)
                    .Property(property.Name)
                    .HasConversion(converter);
            }
        }
    }
}