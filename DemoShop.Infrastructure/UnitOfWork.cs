using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DemoShop.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DemoShopDbContext _context;
    public bool HasActiveTransaction { get; }

    public UnitOfWork(DemoShopDbContext context) =>  _context = context;
    
    public IRepository<TAggregateRoot> GetRepository<TAggregateRoot>() 
        where TAggregateRoot : AggregateRoot 
        => new Repository<TAggregateRoot>(_context);

    public IExecutionStrategy CreateExecutionStrategy(Guid correlationId) 
        => throw new NotImplementedException();

    public Task<IDbContextTransaction?> BeginTransactionAsync(CancellationToken cancellationToken) 
        => throw new NotImplementedException();

    public Task CommitTransactionAsync(IDbContextTransaction? transaction)
        => throw new NotImplementedException();

    public Task RollbackTransaction()
        => throw new NotImplementedException();
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            foreach (var entry in ex.Entries)
            {
                if (entry.Entity is not Entity entity) continue; // Adjust based on your base entity type
                var databaseEntry = await entry.GetDatabaseValuesAsync(cancellationToken);
                if (databaseEntry == null)
                {
                    throw new InvalidOperationException($"Entity {entity.Id} has been deleted by another transaction.");
                }

                entry.OriginalValues.SetValues(databaseEntry);
            }

            // Retry save after resolving conflicts
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void Dispose() => _context.Dispose();
}