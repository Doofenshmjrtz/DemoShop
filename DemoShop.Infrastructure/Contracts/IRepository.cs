using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Infrastructure.Contracts;

public interface IRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(Guid id);
    Task DeleteAsync(Guid id);
}