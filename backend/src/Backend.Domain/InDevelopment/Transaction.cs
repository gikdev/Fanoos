namespace Backend.Domain.InDevelopment;

public record Transaction : Entity {
    public required string          Title           { get; init; }
    public required long            Amount          { get; init; }
    public required DateTimeOffset? OccurredAt      { get; init; }
    public required Guid?           RelatedBudgetId { get; init; }
}
