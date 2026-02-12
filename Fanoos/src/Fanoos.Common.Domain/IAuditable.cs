namespace Fanoos.Common.Domain;

public interface IAuditable
{
    DateTime CreatedAtUtc { get; }
    DateTime? UpdatedAtUtc { get; }
}
