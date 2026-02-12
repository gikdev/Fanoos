namespace Fanoos.Common.Domain;

public interface ISoftDeletable
{
    DateTime? DeletedAtUtc { get; }
    bool IsDeleted => DeletedAtUtc.HasValue;
}
