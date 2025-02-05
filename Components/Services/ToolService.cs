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
        return await _tollRepository.GetAllAsync();
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
        return await _tollRepository.GetToolsByLocation(tollLocation);
    }

    public async Task<IEnumerable<Tool?>> GetTollByCategoryAsync(string tollCategory)
    {
        return await _tollRepository.GetToolsByCategory(tollCategory);
    }
    
    public async Task<IEnumerable<string?>> GetLocationsAsync()
    {
        return await _tollRepository.GetLocationsAsync();
    }

    public async Task<IEnumerable<string?>> GetCategoriesAsync()
    {
        return await _tollRepository.GetCategoriesAsync();
    }

    public async Task<IEnumerable<string?>> GetConditionsAsync()
    {
        return await _tollRepository.GetConditionsAsync();
    }
    
    public async Task AddLocationAsync(string? location)
    {
        await _tollRepository.AddLocationAsync(location);
    }

    public async Task AddCategoryAsync(string category)
    {
        await _tollRepository.AddCategoryAsync(category);
    }
    
    public async Task AddConditionAsync(string category)
    {
        await _tollRepository.AddConditionAsync(category);
    }

    public async Task DeleteLocationsAsync(string location)
    {
        await _tollRepository.DeleteLocationAsync(location);
    }
    
    public async Task DeleteConditionAsync(string condition)
    {
        await _tollRepository.DeleteConditionAsync(condition);
    }
    public async Task DeleteCategoryAsync(string category)
    {
        await _tollRepository.DeleteCategoryAsync(category);
    }
}