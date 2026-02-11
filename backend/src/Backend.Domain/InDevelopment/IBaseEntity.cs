namespace Backend.Domain.InDevelopment;

public interface IBaseEntity : IEntity, IAuditable, ISoftDeletable, IDomainEventProvider { }
