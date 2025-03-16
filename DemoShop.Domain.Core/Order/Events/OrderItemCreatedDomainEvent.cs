using DemoShop.Domain.Core.Common.Interfaces;

namespace DemoShop.Domain.Core.Order.Events;

public class OrderItemCreatedDomainEvent(Guid orderItemId) : IDomainEvent;