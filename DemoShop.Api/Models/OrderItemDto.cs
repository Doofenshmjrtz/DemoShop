namespace DemoShop.Api.Models;

public sealed record OrderItemDto(string Name, decimal UnitPrice, int Quantity);