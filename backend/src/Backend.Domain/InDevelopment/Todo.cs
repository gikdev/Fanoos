namespace Backend.Domain.InDevelopment;

public record Todo : Entity {
    public required string          Title            { get; init; }
    public required string?         Description      { get; init; }
    public required DateTimeOffset? DueDate          { get; init; }
    public required Guid?           RelatedProjectId { get; init; }
    public required DateTimeOffset? CompletedAt      { get; init; }
    public required bool            IsUrgent         { get; init; } = false;
    public required bool            IsImportant      { get; init; } = false;
    public required bool            IsDifficult      { get; init; } = false;
    public required bool            IsImpactful      { get; init; } = false;
}
