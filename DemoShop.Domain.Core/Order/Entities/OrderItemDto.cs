namespace DemoShop.Domain.Core.Order.Entities;

public sealed record OrderItemDto(string Name, decimal UnitPrice, int Quantity);