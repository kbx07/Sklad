namespace Sklad.Components.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T?>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity, int id);
    Task DeleteAsync(int id);
}