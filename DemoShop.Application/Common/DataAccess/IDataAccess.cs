using DemoShop.Domain.Core.Order;
using DemoShop.Domain.Core.Order.Entities;

namespace DemoShop.Application.Common.DataAccess;

public interface IDataAccess
{
    public Order GetOrder(Guid orderId);
    public List<Order> GetOrderList();
    public OrderItem GetOrderItem(Guid orderItemId);
    public List<OrderItem> GetOrderItems(Guid orderId);
    public long CreateOrderItem(Guid orderId, string name, decimal price, int quantity);
    public long CreateOrder();
}