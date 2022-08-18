namespace Identities.Domain.Common;

public abstract class Entity
{
    private readonly Queue<object> _domainEvents = new();

    public bool HasDomainEvents => _domainEvents.Any();

    protected void AddDomainEvent(object eventItem)
    {
        _domainEvents.Enqueue(eventItem);
    }
        
    public IList<object> TakeDomainEvents()
    {
        var domainEvents = _domainEvents.ToList();
        _domainEvents.Clear();

        return domainEvents;
    }
}