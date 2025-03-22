using DemoShop.Domain.Core.Common.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoShop.Infrastructure.Contracts;

public interface IUnitOfWork : IDisposable
{
    bool HasActiveTransaction { get; }
    IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() where TAggregateRoot : AggregateRoot;
    IExecutionStrategy CreateExecutionStrategy(Guid correlationId);
    Task<IDbContextTransaction?> BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(IDbContextTransaction? transaction);
    Task RollbackTransaction();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}