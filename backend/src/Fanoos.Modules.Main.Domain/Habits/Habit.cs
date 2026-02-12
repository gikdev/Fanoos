using Fanoos.Common.Domain;

namespace Fanoos.Modules.Main.Domain.Habits;

public class Habit : HasDomainEvents, IAggregateRoot, IAuditable {
    private readonly List<HabitCompletion> _completions = [];

    private Habit() { }

    public Guid      Id              { get; init; }
    public string    Name            { get; private set; }
    public string?   Description     { get; private set; }
    public DateTime? LastCompletedAt { get; private set; }
    public bool      IsCompleted     => LastCompletedAt.HasValue;
    public DateTime  CreatedAtUtc    { get; init; }
    public DateTime? UpdatedAtUtc    { get; private set; }

    /// <summary>Completions of a habit</summary>
    public IReadOnlyCollection<HabitCompletion> Completions => _completions.AsReadOnly();

    public static Result<Habit> Create(
        string  name,
        string? description,
        Guid?   id = null
    ) {
        DateTime now = DateTime.UtcNow;

        var habit = new Habit {
            Id           = id ?? Guid.NewGuid(),
            Name         = name,
            Description  = description,
            CreatedAtUtc = now,
        };

        return habit;
    }
}
