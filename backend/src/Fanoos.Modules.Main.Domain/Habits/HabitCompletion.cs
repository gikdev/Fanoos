using Fanoos.Common.Domain;

namespace Fanoos.Modules.Main.Domain.Habits;

public class HabitCompletion : IAuditable, IEntity {
    public Guid      Id             { get; init; }
    public string?   Note           { get; private set; }
    public DateTime  CompletedAtUtc { get; init; }
    public DateTime  CreatedAtUtc   { get; init; }
    public DateTime? UpdatedAtUtc   { get; private set; }
}
