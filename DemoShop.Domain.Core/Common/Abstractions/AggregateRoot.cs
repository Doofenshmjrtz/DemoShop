using DemoShop.Domain.Core.Common.Interfaces;

namespace DemoShop.Domain.Core.Common.Abstractions;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    public List<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    public void ClearDomainEvents() => _domainEvents.Clear();
    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public static IEnumerable<Entity> GetEntities(AggregateRoot aggregate)
    {
        return aggregate.GetType()
            .GetProperties()
            .Where(p => typeof(IEnumerable<Entity>).IsAssignableFrom(p.PropertyType))
            .SelectMany(p => p.GetValue(aggregate) as IEnumerable<Entity> ?? []);
    }
}