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

    public void MarkItemAsDelivered(Guid orderItemId) => GetOrderItem(orderItemId).MarkAsDelivered();

    public void MarkAsDelivered()
    {
        if (Status != OrderStatus.Processing)
            throw new InvalidOperationException("Can only mark orders as delivered when they are in Processing status");

        if (_items.Any(i => i.Status != OrderItemStatus.Delivered))
            throw new InvalidOperationException("Cannot mark order as delivered until all items are delivered");

        Status = OrderStatus.Delivered;
    }

    public void MarkItemAsCancelled(Guid orderItemId) => GetOrderItem(orderItemId).MarkAsCancelled();

    public void MarkAsCanceled()
    {
        if (Status == OrderStatus.Delivered)
            throw new InvalidOperationException("Cannot cancel a delivered order");
        
        if (_items.Any(i => i.Status != OrderItemStatus.Cancelled))
            throw new InvalidOperationException("Cannot mark order as cancelled until all items are cancelled");

        Status = OrderStatus.Canceled;
    }
    
    private OrderItem GetOrderItem(Guid orderItemId) => _items.FirstOrDefault(i => i.Id() == orderItemId) ?? throw new InvalidOperationException($"Item with id '{orderItemId}' does not exist in the order");

    private void EnsureOrderIsModifiable() => 
        _ = Status != OrderStatus.Draft 
            ? throw new InvalidOperationException("Can only modify orders that are in Draft status") 
            : 0;
}