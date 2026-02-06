namespace Backend.Domain.InDevelopment;

public record Note : Entity {
    public required string Title   { get; init; }
    public required string Content { get; init; }
}
