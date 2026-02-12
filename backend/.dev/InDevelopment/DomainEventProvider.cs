namespace Backend.Domain.InDevelopment;

public class DomainEventProvider : IDomainEventProvider
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents()
        => _domainEvents.Clear();

    public void RaiseDomainEvent(IDomainEvent domainEvent)
        => _domainEvents.Add(domainEvent);
}
