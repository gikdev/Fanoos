namespace Backend.Domain.InDevelopment;

public record Entity {
    public required Guid Id { get; init; }

    public required DateTimeOffset  CreatedAt { get; init; }
    public required DateTimeOffset? UpdatedAt { get; init; }
    public required DateTimeOffset? DeletedAt { get; init; }
}
