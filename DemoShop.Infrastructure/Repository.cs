using System.Linq.Expressions;
using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DemoShop.Infrastructure;

public class Repository<TAggregateRoot>(DemoShopDbContext context) : IRepository<TAggregateRoot>
    where TAggregateRoot : AggregateRoot
{
    private readonly DbSet<TAggregateRoot> _dbSet = context.Set<TAggregateRoot>();

    public async Task<IEnumerable<TAggregateRoot>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task<TAggregateRoot?> GetAsync(
        Guid id,
        Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null,
        CancellationToken cancellationToken = default)
    {
        var query = _dbSet
            .AsNoTracking()
            .Where(e => e.Id == id);
        
        if (include != null)
        {
            query = include(query);
        }
    
        return await query.FirstOrDefaultAsync(cancellationToken);
    }
    
    public async Task AddAsync(TAggregateRoot entity) => await _dbSet.AddAsync(entity);

    public void Update(TAggregateRoot aggregate) => _dbSet.Update(aggregate);   
    public void Delete(TAggregateRoot aggregate) => _dbSet.Remove(aggregate);
}