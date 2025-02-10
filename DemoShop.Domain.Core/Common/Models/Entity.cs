using DemoShop.Domain.Core.Common.Interfaces;

namespace DemoShop.Domain.Core.Common.Models;

public abstract class Entity : IEquatable<Entity>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    private readonly Guid _id;
    internal Entity() => _id = Guid.NewGuid();
    
    public bool Equals(Entity? other) => Equals((object?)other);
    public override bool Equals(object? obj) => obj is Entity entity && _id.Equals(entity._id);

    public override int GetHashCode() => _id.GetHashCode() * 4237;

    public static bool operator ==(Entity? left, Entity? right) => Equals(left, right);

    public static bool operator !=(Entity? left, Entity? right) => !Equals(left, right);

    internal Guid Id() => _id;
    
    public List<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();

    internal static Entity Create() => throw new NotImplementedException("This method should be implemented in a child class.");
    
    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}