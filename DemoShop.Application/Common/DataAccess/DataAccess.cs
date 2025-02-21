using DemoShop.Domain.Core.Order.Entities;
using O = DemoShop.Domain.Core.Order.Order;

namespace DemoShop.Application.Common.DataAccess;

public class DataAccess : IDataAccess
{
    private readonly O _order;

    public DataAccess()
    {
        _order = O.Create();
        _order.AddItem("Computer", 123.45m, 2);
        _order.AddItem("Car", 513.33m, 10);
        _order.AddItem("Bread", 3.11m, 1);
    }

    public O GetOrder()
    {
        return _order;
    }

    public OrderItem GetOrderItem(Guid itemId)
    {
        foreach (var item in _order.Items)
        {
            if (item.Id == itemId) 
                return item;
        }
        throw new KeyNotFoundException();
    }

    public List<OrderItem> GetOrderItems()
    {
        return _order.Items.ToList();
    }

    public long AddItem(string name, decimal price, int quantity)
    {
        _order.AddItem(name, price, quantity);
        return _order.Items.Last().OrderItemId;
    }
}