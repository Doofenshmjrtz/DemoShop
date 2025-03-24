using DemoShop.Domain.Core.Common.Abstractions;

namespace DemoShop.Infrastructure.Contracts;

public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
{
    Task AddAsync(TAggregateRoot entity);

    Task<TAggregateRoot?> GetByIdAsync(
        Guid id,
        Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null,
        CancellationToken cancellationToken = default);

    void Update(TAggregateRoot entity);
}