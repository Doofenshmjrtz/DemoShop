using DemoShop.Domain.Core.Common.Interfaces;

namespace DemoShop.Domain.Core.Common.Abstractions;

public abstract class Entity : IEquatable<Entity>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public Guid Id { get; init; }
    internal Entity() => Id = Guid.NewGuid();
    
    public bool Equals(Entity? other) => Equals((object?)other);
    public override bool Equals(object? obj) => obj is Entity entity && Id.Equals(entity.Id);

    public override int GetHashCode() => Id.GetHashCode() * 4237;

    public static bool operator ==(Entity? left, Entity? right) => Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right) => !Equals(left, right);
    
    public List<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    internal static Entity Create() => throw new NotImplementedException("This method should be implemented in a child class.");
    
    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}