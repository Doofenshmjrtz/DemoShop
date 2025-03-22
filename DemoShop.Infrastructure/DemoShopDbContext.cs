using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoShop.Infrastructure;

public class DemoShopDbContext(DbContextOptions<DemoShopDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoShopDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}