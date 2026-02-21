namespace Backend.Domain.InDevelopment;

public record SimpleContact : Entity
{
  public required string       Name { get; init; }
  public required List<string> Phones { get; init; }
  public required string?      Note { get; init; }
}
