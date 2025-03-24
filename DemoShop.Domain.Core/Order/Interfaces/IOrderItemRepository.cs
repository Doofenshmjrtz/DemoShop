using DemoShop.Domain.Core.Order.Entities;

namespace DemoShop.Domain.Core.Order.Interfaces;

public interface IOrderItemRepository
{
    public Task<OrderItem?> GetOrderItemByIdAsync();
}