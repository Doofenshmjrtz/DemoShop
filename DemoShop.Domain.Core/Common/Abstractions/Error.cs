namespace DemoShop.Domain.Core.Common.Abstractions;

public record Error(string Code, string? Description = null)
{
    public static readonly Error None = new (string.Empty);
}
