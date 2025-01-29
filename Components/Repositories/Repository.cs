using Microsoft.EntityFrameworkCore;
using MudBlazor;
using Sklad.Components.Data;
using Sklad.Components.Interfaces;

namespace Sklad.Components.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;
    
    protected Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await _dbSet.OrderByDescending(x => EF.Property<int>(x, "Id")).ToListAsync();
    }


    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity, int id)
    {
        
        // Znajdź istniejący obiekt na podstawie ID
        var existingEntity = await GetByIdAsync(id);
        if (existingEntity == null)
        {
            throw new InvalidOperationException("Entity not found.");
        }

        // Zaktualizuj właściwości istniejącego obiektu
        _context.Entry(existingEntity).CurrentValues.SetValues(entity);

        // Zapisz zmiany w bazie danych
        await _context.SaveChangesAsync();
    }



    
    


    
    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}