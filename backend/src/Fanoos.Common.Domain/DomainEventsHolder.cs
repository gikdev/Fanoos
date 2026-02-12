namespace Fanoos.Common.Domain;

public abstract class HasDomainEvents {
    private readonly List<IDomainEvent> _domainEvents = [];

    protected HasDomainEvents() { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();

    public void ClearDomainEvents() {
        _domainEvents.Clear();
    }

    protected void Raise(IDomainEvent domainEvent) {
        _domainEvents.Add(domainEvent);
    }
}
