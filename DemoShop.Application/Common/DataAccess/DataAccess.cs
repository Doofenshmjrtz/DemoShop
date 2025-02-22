using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Domain.Core.Order;

namespace DemoShop.Application.Common.DataAccess;

public class DataAccess : IDataAccess
{
    private readonly List<Order> _orders = [];

    public DataAccess()
    {
        var order = Order.Create();
        order.AddItem("Computer", 123.45m, 2);
        order.AddItem("Car", 513.33m, 10);
        order.AddItem("Bread", 3.11m, 1);
        
        _orders.Add(order);
    }
    
    public Order GetOrder(Guid orderId) => _orders.FirstOrDefault(o => o.Id == orderId)!;
    
    public List<Order> GetOrders() => _orders;

    public OrderItem GetOrderItem(Guid orderItemId)
    {
        foreach (var item in from order in _orders from item in order.Items where item.Id == orderItemId select item)
            return item;
        throw new KeyNotFoundException();
    }

    public List<OrderItem> GetOrderItems(Guid orderId)
    {
        foreach (var order in _orders.Where(order => order.Id == orderId))
            return order.Items.ToList();
        throw new KeyNotFoundException();
    }

    public long AddOrderItem(Guid orderId, string name, decimal price, int quantity)
    {
        foreach (var order in _orders.Where(order => order.Id == orderId))
        {
            order.AddItem(name, price, quantity);
            return order.Items.Last().OrderItemId;
        }
        throw new KeyNotFoundException();
    }

    public long AddOrder()
    {
        var order = Order.Create();
        _orders.Add(order);
        return order.Items.Last().OrderItemId;
    }
}