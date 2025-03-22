using System.Linq.Expressions;
using DemoShop.Domain.Core.Common.Abstractions;
using Microsoft.EntityFrameworkCore.Query;

namespace DemoShop.Infrastructure.Contracts;

public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
{
    Task<IEnumerable<TAggregateRoot>> GetAllAsync();
    Task<TAggregateRoot?> GetAsync(
        Guid id,
        Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null,
        CancellationToken cancellationToken = default);
    void Update(TAggregateRoot aggregateRoot);
    // Task<int> UpdateAsync(
    //     Expression<Func<SetPropertyCalls<TAggregateRoot>, SetPropertyCalls<TAggregateRoot>>> aggregate);
    void Delete(TAggregateRoot aggregate);
    Task AddAsync(TAggregateRoot aggregate);
}