namespace Backend.Domain.InDevelopment;

public record Budget : Entity {
    public required string Name      { get; init; }
    public required long   Remaining { get; init; } = 0;
};
