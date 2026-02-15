namespace Backend.Domain.InDevelopment;

public record Thought : Entity {
    public required string          Title                { get; init; }
    public required string?         AiFeedback           { get; init; }
    public required string?         Description          { get; init; }
    public required bool            IsClear              { get; init; } = false;
    public required bool            IsHighlighted        { get; init; } = false;
    public required string[]        Tags                 { get; init; }
    public required YoungSchema[]?  ProbableYoungSchemas { get; init; }
    public required DateTimeOffset? ArchivedAt           { get; init; }
}
