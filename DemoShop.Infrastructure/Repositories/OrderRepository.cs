using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Domain.Core.Order.Interfaces;
using DemoShop.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DemoShop.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly DemoShopDbContext _dbContext;
    public IUnitOfWork UnitOfWork { get; }

    public OrderRepository(DemoShopDbContext dbContext, IUnitOfWork unitOfWork) 
        : base(dbContext)
    {
        _dbContext = dbContext;
        UnitOfWork = unitOfWork;
    }

    public async Task<Order?> GetOrderByIdTestAsync(Guid orderId, CancellationToken cancellationToken)
    {
        return await _dbContext
            .Orders
            .Include(o => o.Items
                .Where(i => i.OrderId == orderId))
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
    }

    public Task<OrderItem?> GetOrderItemByIdAsync(Guid orderId, Guid orderItemId)
    {
        throw new NotImplementedException();
    }

    public void UpdateOrderItem(Order order)
    {
        _dbContext.Entry(order).State = EntityState.Modified;
        _dbContext.OrderItems.Add(order.Items.LastOrDefault()!);
    }
}