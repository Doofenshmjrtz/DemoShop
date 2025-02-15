using DemoShop.Domain.Core.Order.Entities;

namespace DemoShop.Domain.Core.Common.Interfaces;

public interface IDataAccess
{
    public Order.Order GetOrder();
    public OrderItem GetOrderItem(Guid itemId);
    public List<OrderItem> GetOrderItems();
    public OrderItem AddItem(string name, decimal price, int quantity);
}