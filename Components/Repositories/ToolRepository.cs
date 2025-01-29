using Microsoft.EntityFrameworkCore;
using Sklad.Components.Data;
using Sklad.Components.Interfaces;
using Sklad.Components.Models;

namespace Sklad.Components.Repositories;

public class ToolRepository : Repository<Tool>, ITollRepository
{
    private readonly AppDbContext _context;
    
    public ToolRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Tool>> GetToolsByLocation(string location)
    {
        return await _context.Tool
            .Where(f => f.Location == location)
            .ToListAsync();
    }

    public async Task<IEnumerable<Tool>> GetToolsByName(string name)
    {
        return await _context.Tool
            .Where(f => f.Name == name)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Tool>> GetToolsByCategory(string category)
    {
        return await _context.Tool
            .Where(f => f.Category == category)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<string?>> GetLocationsAsync()
    {
        // Pobierz listę unikalnych lokalizacji z bazy danych
        return await _context.Tool.Select(t => t.Location).Distinct().ToListAsync();
    }

    public async Task<IEnumerable<string?>> GetCategoriesAsync()
    {
        // Pobierz listę unikalnych kategorii z bazy danych
        return await _context.Tool.Select(t => t.Category).Distinct().ToListAsync();
    }

    public async Task<IEnumerable<string?>> GetConditionsAsync()
    {
        // Pobierz listę unikalnych stanów z bazy danych
        return await _context.Tool.Select(t => t.Condition).Distinct().ToListAsync();
    }
    
    public async Task AddLocationAsync(string location)
    {
        if (!await _context.Tool.AnyAsync(t => t.Location == location))
        {
            _context.Tool.Add(new Tool { Location = location });
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task AddCategoryAsync(string category)
    {
        if (!await _context.Tool.AnyAsync(t => t.Category == category))
        {
            _context.Tool.Add(new Tool { Category = category });
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddConditionAsync(string condition)
    {
        if (!await _context.Tool.AnyAsync(t => t.Condition == condition))
        {
            _context.Tool.Add(new Tool { Condition = condition });
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteLocationAsync(string location)
    {
        var toolsWithLocation = await _context.Tool.Where(t => t.Location == location).ToListAsync();
    
        if (toolsWithLocation.Any())
        {
            _context.Tool.RemoveRange(toolsWithLocation);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteCategoryAsync(string category)
    {
        var toolsWithCategory = await _context.Tool.Where(t => t.Category == category).ToListAsync();
    
        if (toolsWithCategory.Any())
        {
            _context.Tool.RemoveRange(toolsWithCategory);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteConditionAsync(string condition)
    {
        var toolsWithCategory = await _context.Tool.Where(t => t.Condition == condition).ToListAsync();
    
        if (toolsWithCategory.Any())
        {
            _context.Tool.RemoveRange(toolsWithCategory);
            await _context.SaveChangesAsync();
        }
    }

   
    
 
    
 


    
}