namespace Backend.Domain.InDevelopment;

public interface ISoftDeletable
{
    DateTime? DeletedAtUtc { get; }
    bool IsDeleted => DeletedAtUtc.HasValue;
}
