using Sklad.Components.Models;

namespace Sklad.Components.Interfaces;

public interface ITollRepository : IRepository<Tool>
{
    Task<IEnumerable<Tool>> GetToolsByLocation(string location);
    Task<IEnumerable<Tool>> GetToolsByName(string location);
    Task<IEnumerable<Tool>> GetToolsByCategory(string category);
    Task<IEnumerable<string?>> GetLocationsAsync();
    Task<IEnumerable<string?>> GetCategoriesAsync();
    Task<IEnumerable<string?>> GetConditionsAsync();

    Task AddLocationAsync(string location);
    Task AddCategoryAsync(string category);
    Task AddConditionAsync(string category);
    Task DeleteLocationAsync(string location);
    Task DeleteCategoryAsync(string category);
    Task DeleteConditionAsync(string condition);




}