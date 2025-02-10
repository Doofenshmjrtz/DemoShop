using System.Collections.ObjectModel;
using DemoShop.Domain.Core.Common.Models;
using DemoShop.Domain.Core.Order.Entities;
using DemoShop.Domain.Core.Order.Enums;
using DemoShop.Domain.Core.Order.Events; 

namespace DemoShop.Domain.Core.Order;

public sealed class Order : AggregateRoot
{
    private readonly List<OrderItem> _items = [];
    public DateTime OrderDate { get; private set; }
    public decimal OrderTotal { get; private set; }
    public OrderStatus Status { get; private set; }
    public ReadOnlyCollection<OrderItem> Items { get; private set; }

    private Order()
    {
        OrderDate = DateTime.UtcNow;
        OrderTotal = _items.Sum(item => item.Subtotal);
        Status = OrderStatus.Draft;
        Items = _items.AsReadOnly();
    }
    
    public new static Order Create()
    {
        var order = new Order();
        order.Raise(new OrderCreatedDomainEvent(order.Id()));
        return order;
    }

    public void AddItem(decimal unitPrice, int quantity)
    {
        EnsureOrderIsModifiable();
        _items.Add(OrderItem.Create(unitPrice, quantity));
        OrderTotal = _items.Sum(item => item.Subtotal); 
    }

    public void RemoveItem(Guid orderItemId)
    {
        EnsureOrderIsModifiable();
        var item = _items.FirstOrDefault(i => i.Id() == orderItemId);
        if (item == null) 
            throw new InvalidOperationException($"Item with id - '{orderItemId}' does no exist in the bucket");
        _items.Remove(item);
        OrderTotal = _items.Sum(orderItem => orderItem.Subtotal);
    }
    
    public void MarkAsProcessing()
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Can only submit orders that are in Draft status");

        if (_items.Count == 0)
            throw new InvalidOperationException("Cannot submit an empty order for processing");

        Status = OrderStatus.Processing;
        OrderTotal = _items.Sum(item => item.Subtotal);
    }

    public void MarkAsDelivered(Guid orderItemId)
    {
        if (Status != OrderStatus.Processing)
            throw new InvalidOperationException("Can only deliver items when order is in Processing status");

        var item = _items.FirstOrDefault(i => i.Id() == orderItemId);
        if (item == null)
            throw new InvalidOperationException($"Item with id '{orderItemId}' does not exist in the order");

        item.MarkItemAsDelivered();

        if (_items.All(i => i.IsDelivered))
            Status = OrderStatus.Delivered;
    }

    public void MarkAsDelivered()
    {
        if (Status != OrderStatus.Processing)
            throw new InvalidOperationException("Can only mark orders as delivered when they are in Processing status");

        if (_items.Count == 0)
            throw new InvalidOperationException("Cannot mark an empty order as delivered");

        if (!_items.All(i => i.IsDelivered))
            throw new InvalidOperationException("Cannot mark order as delivered until all items are delivered");

        Status = OrderStatus.Delivered;
    }

    public void MarkAsCanceled()
    {
        if (Status == OrderStatus.Delivered)
            throw new InvalidOperationException("Cannot cancel a delivered order");

        Status = OrderStatus.Canceled;
    }

    private void EnsureOrderIsModifiable()
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Can only modify orders that are in Draft status");
    }
}