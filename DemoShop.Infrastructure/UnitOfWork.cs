using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Infrastructure.Contracts;
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
        => await _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();
}