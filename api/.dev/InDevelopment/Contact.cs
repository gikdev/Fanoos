namespace Backend.Domain.InDevelopment;

public enum RelationshipType
{
  Family,
  Friend,
  Colleague,
  Acquaintance,
  Other
}

public enum MbtiType
{
  Enfj, Enfp, Entj, Entp,
  Esfj, Esfp, Estj, Estp,
  Infj, Infp, Intj, Intp,
  Isfj, Isfp, Istj, Istp,
}

public record Contact : Entity
{
  public required string FirstName { get; init; }
  public required string LastName { get; init; }
  public required string? MiddleName { get; init; }
  public required string? Nickname { get; init; }

  public required List<string> Phones { get; init; }
  public required List<string> Emails { get; init; }
  public required Dictionary<string, string> SocialHandles { get; init; }

  public required DateTime? Birthday { get; init; }
  public required MbtiType? MbtiType { get; init; }
  public required string? Notes { get; init; }

  public required RelationshipType Relationship { get; init; }
  public required DateTime? FirstMetAt { get; init; }

  public required List<string> Tags { get; init; }
}

