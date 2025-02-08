using Sklad.Components.Models;

namespace Sklad.Components.Interfaces;

public interface ITollRepository : IRepository<Tool>
{
    Task<IEnumerable<Tool>> GetToolsByLocationName(string locationName);
    Task<IEnumerable<Tool>> GetToolsByName(string location);
    Task<IEnumerable<Tool>> GetToolsByExactLocationName(string exactLocationName);
    Task<IEnumerable<Location?>> GetLocationsAsync();
    Task<IEnumerable<ExactLocation?>> GetExactLocationsAsync();
    Task<IEnumerable<Condition?>> GetConditionsAsync();

    Task<Location?> AddLocationAsync(string? locationName);
    Task<ExactLocation?> AddExactLocationAsync(string exactLocationName);
    Task<Condition?> AddConditionAsync(string categoryName);
    Task DeleteLocationAsync(string location);
    Task DeleteExactLocationAsync(string exactLocation);
    Task DeleteConditionAsync(string condition);




}