namespace DemoShop.Domain.Core.Common.Abstractions;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; init; }
    internal Entity() => Id = Guid.NewGuid();
    
    public bool Equals(Entity? other) => Equals((object?)other);
    
    public override bool Equals(object? obj) => obj is Entity entity && Id.Equals(entity.Id);

    public override int GetHashCode() => Id.GetHashCode() * 4237;

    public static bool operator ==(Entity? left, Entity? right) => Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right) => !Equals(left, right);
    
    internal static Entity Create() => throw new NotImplementedException("This method should be implemented in a child class.");
}