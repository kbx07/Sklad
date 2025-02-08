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
    
    public async Task<IEnumerable<Tool>> GetToolsByLocationName(string locationName)
    {
        return await _context.Tool
            .Include(t => t.Location)
            .Where(t => t.Location != null && t.Location.Name == locationName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Tool>> GetToolsByName(string name)
    {
        return await _context.Tool
            .Where(f => f.Name == name)
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Tool>> GetToolsByExactLocationName(string exactLocationName)
    {
        return await _context.Tool
            .Include(t => t.ExactLocation)
            .Where(t => t.ExactLocation != null && t.ExactLocation.Name == exactLocationName)
            .ToListAsync();
    }

    
    public async Task<IEnumerable<Location?>> GetLocationsAsync()
    {
        return await _context.Location
            .AsNoTracking()         
            .ToListAsync();
    }


    public async Task<IEnumerable<ExactLocation?>> GetExactLocationsAsync()
    {
        return await _context.ExactLocation
            .AsNoTracking()         
            .ToListAsync();
    }



    public async Task<IEnumerable<Condition?>> GetConditionsAsync()
    {
        return await _context.Condition
            .AsNoTracking()         
            .ToListAsync();
    }
    
    public async Task<Location?> AddLocationAsync(string? locationName)
    {
        var location = await _context.Location.FirstOrDefaultAsync(l => l.Name == locationName);

        if (location == null)
        {
            location = new Location(){Name = locationName};
            _context.Location.Add(location);
            await _context.SaveChangesAsync();
        }
        return location;
    }

    public async Task<ExactLocation?> AddExactLocationAsync(string exactLocationName)
    {
        var exactLocation = await _context.ExactLocation.FirstOrDefaultAsync(l => l.Name == exactLocationName);

        if (exactLocation == null)
        {
            exactLocation = new ExactLocation(){Name = exactLocationName};
            _context.ExactLocation.Add(exactLocation);
            await _context.SaveChangesAsync();
        }
        return exactLocation;
    }
    
    public async Task<Condition?> AddConditionAsync(string conditionName)
    {
       var condition = await _context.Condition.FirstOrDefaultAsync(c => c.Name == conditionName);

       if (condition == null)
       {
           condition = new Condition(){Name = conditionName};
           _context.Condition.Add(condition);
           await _context.SaveChangesAsync();
       }
       return condition;
    }




    public async Task DeleteLocationAsync(string locationName)
    {
        var locationEntity = await _context.Location
            .FirstOrDefaultAsync(l => l.Name == locationName);

        if (locationEntity != null)
        {
            _context.Location.Remove(locationEntity);
            await _context.SaveChangesAsync();
        }
    }


    public async Task DeleteExactLocationAsync(string exactLocation)
    {
        var exactLocationEntity = await _context.ExactLocation
            .FirstOrDefaultAsync(l => l.Name == exactLocation);

        if (exactLocationEntity != null)
        {
            _context.ExactLocation.Remove(exactLocationEntity);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteConditionAsync(string condition)
    {
        var conditionEntity = await _context.Condition
            .FirstOrDefaultAsync(l => l.Name == condition);
    
        if (conditionEntity != null)
        {
            _context.Condition.Remove(conditionEntity);
            await _context.SaveChangesAsync();
        }
    }
    
}