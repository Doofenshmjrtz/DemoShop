using DemoShop.Domain.Core.Common.Abstractions;
using DemoShop.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DemoShop.Infrastructure;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly DemoShopDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DemoShopDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public async Task<T?> GetAsync(Guid id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public async Task UpdateAsync(Guid id)
    { 
        var order = await GetAsync(id);
        if (order != null) _dbSet.Update(order);
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await GetAsync(id);
        if (order != null) _dbSet.Remove(order);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}