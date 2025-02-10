using DemoShop.Domain.Core.Common.Interfaces;

namespace DemoShop.Domain.Core.Order.Events;

public sealed record OrderCreatedDomainEvent(Guid OrderId) : IDomainEvent;