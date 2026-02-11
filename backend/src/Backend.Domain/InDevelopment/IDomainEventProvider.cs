namespace Backend.Domain.InDevelopment;

public interface IDomainEventProvider
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    void RaiseDomainEvent(IDomainEvent domainEvent);
    void ClearDomainEvents();
}
