using DemoShop.Domain.Core.Order.Entities;

namespace DemoShop.Application.Common.DataAccess;

public interface IDataAccess
{
    public Domain.Core.Order.Order GetOrder();
    public OrderItem GetOrderItem(Guid itemId);
    public List<OrderItem> GetOrderItems();
    public long AddItem(string name, decimal price, int quantity);
}