using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Infrastructure.Contracts;

namespace DemoShop.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DemoShopDbContext _context;

    public UnitOfWork(DemoShopDbContext context)
    {
        _context = context;
    }
    
    public IRepository<T> GetRepository<T>() where T : Entity => new Repository<T>(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();
}