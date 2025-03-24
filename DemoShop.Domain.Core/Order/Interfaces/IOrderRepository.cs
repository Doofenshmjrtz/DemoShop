using DemoShop.Domain.Core.Order.Entities;

namespace DemoShop.Domain.Core.Order.Interfaces;

public interface IOrderRepository
{
    public Task<OrderItem?> GetOrderItemByIdAsync(Guid orderId, Guid orderItemId);
    public Task AddOrderItemAsync(OrderItem orderItem);
}