namespace Backend.Domain.InDevelopment;

public record Project : Entity {
    public required string          Title       { get; init; }
    public required string?         Description { get; init; }
    public required DateTimeOffset? StartDate   { get; init; }
    public required DateTimeOffset? DueDate     { get; init; }
    public required bool            IsArchived  { get; init; } = false;
}
