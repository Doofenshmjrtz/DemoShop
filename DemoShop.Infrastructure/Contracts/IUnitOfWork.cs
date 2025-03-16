using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Infrastructure.Contracts;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> GetRepository<T>() where T : Entity;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}