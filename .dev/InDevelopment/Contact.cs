namespace Backend.Domain.InDevelopment;

public enum RelationshipType {
    Family,
    Friend,
    Colleague,
    Acquaintance,
    Other
}

public enum MbtiType {
    Istj,
    Isfj,
    Infj,
    Intj,
    Istp,
    Isfp,
    Infp,
    Intp,
    Estp,
    Esfp,
    Enfp,
    Entp,
    Estj,
    Esfj,
    Enfj,
    Entj
}

public record Contact {
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string? Nickname { get; init; }
    public required List<string> Phones { get; init; }
    public required List<string> Emails { get; init; }
    public required Dictionary<string, string> SocialHandles { get; init; }
    public required DateTime? Birthday { get; init; }
    public required MbtiType? MbtiType { get; init; }
    public required string? Notes { get; init; }
    public required RelationshipType Relationship { get; init; }
    public required DateTime? FirstMetDate { get; init; }
    public required List<string> Tags { get; init; }
    public required DateTime  CreatedAtUtc { get; init; }
    public required DateTime? UpdatedAtUtc { get; init; }
    public required DateTime? DeletedAtUtc { get; init; }
}
