using Sklad.Components.Interfaces;
using Sklad.Components.Models;

namespace Sklad.Components.Services;

public class ToolService
{
    private readonly ITollRepository _tollRepository;
    
    public ToolService(ITollRepository tollRepository)
    {
        _tollRepository = tollRepository;
    }

    public async Task<IEnumerable<Tool?>> GetAllToolsAsync()
    {
        return await _tollRepository.GetAllAsync(
            tool => tool.Location,
            tool => tool.ExactLocation,
            tool => tool.Condition);
    }

    public async Task<Tool?> GetToolByIdAsync(int tollId)
    {
        return await _tollRepository.GetByIdAsync(tollId);
    }

    public async Task AddToolAsync(Tool tool)
    {
        await _tollRepository.AddAsync(tool);
    }

    public async Task UpdateToolAsync(Tool tool, int toolId)
    {
        if (tool.Id != toolId)
        {
            throw new InvalidOperationException("Tool ID mismatch.");
        }

        await _tollRepository.UpdateAsync(tool, toolId);
    }

    public async Task DeleteToolAsync(int tollId)
    {
        await _tollRepository.DeleteAsync(tollId);
    }

    public async Task<IEnumerable<Tool?>> GetTollByNameAsync(string tollName)
    {
        return await _tollRepository.GetToolsByName(tollName);
    }
    
    public async Task<IEnumerable<Tool?>> GetTollByLocationAsync(string tollLocation)
    {
        return await _tollRepository.GetToolsByLocationName(tollLocation);
    }

    public async Task<IEnumerable<Tool?>> GetTollByExactLocation(string exactLocation)
    {
        return await _tollRepository.GetToolsByExactLocationName(exactLocation);
    }
    
    public async Task<IEnumerable<Location?>> GetLocationsAsync()
    {
        return await _tollRepository.GetLocationsAsync();
    }
    
    public async Task<IEnumerable<ExactLocation?>> GetExactLocationsAsync()
    {
        return await _tollRepository.GetExactLocationsAsync();
    }
    
    public async Task<IEnumerable<Condition?>> GetConditionsAsync()
    {
        return await _tollRepository.GetConditionsAsync();
    }

    public async Task<ExactLocation?> AddExactLocationAsync(string exactLocationName)
    {
      return await _tollRepository.AddExactLocationAsync(exactLocationName);
    }
    
    public async Task<Location?> AddLocationAsync(string? location)
    {
        return await _tollRepository.AddLocationAsync(location);
    }
    
    public async Task<Condition?> AddConditionAsync(string category)
    {
        return await _tollRepository.AddConditionAsync(category);
    }

    public async Task DeleteLocationsAsync(string location)
    {
        await _tollRepository.DeleteLocationAsync(location);
    }
    
    public async Task DeleteConditionAsync(string condition)
    {
        await _tollRepository.DeleteConditionAsync(condition);
    }
    public async Task DeleteExactLocationAsync(string category)
    {
        await _tollRepository.DeleteExactLocationAsync(category);
    }
}