namespace Backend.Domain.InDevelopment;

public record HabitCompletion : Entity {
    public required string?        Note        { get; init; }
    public required DateTimeOffset CompletedAt { get; init; }
}
