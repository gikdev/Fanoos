using Fanoos.Common.Domain;

namespace Fanoos.Modules.Main.Domain.Todos;

public class Todo : HasDomainEvents, IAggregateRoot, IAuditable {
    public Guid                   Id               { get; private init; }
    public TodoTitle              Title            { get; private set; }
    public string?                Description      { get; private set; }
    public DateTime?              DueDate          { get; private set; }
    public DateTime?              CompletedAt      { get; private set; }
    public EisenhowerMatrix       Eisenhower       { get; private set; }
    public DifficultyImpactMatrix DifficultyImpact { get; private set; }
    public DateTime               CreatedAtUtc     { get; private init; }
    public DateTime?              UpdatedAtUtc     { get; private set; }

    public static Result<Todo> Create(
        TodoTitle               todoTitle,
        string?                 description,
        DateTime?               dueDate,
        DateTime?               completedAt,
        EisenhowerMatrix?       eisenhower,
        DifficultyImpactMatrix? difficultyImpact,
        Guid?                   id = null
    ) {
        DateTime now                     = DateTime.UtcNow;
        var      defaultEisenhower       = EisenhowerMatrix.CreateDefault();
        var      defaultDifficultyImpact = DifficultyImpactMatrix.CreateDefault();

        var todo = new Todo {
            Id               = id ?? Guid.NewGuid(),
            Title            = todoTitle,
            Description      = description,
            Eisenhower       = eisenhower       ?? defaultEisenhower,
            DifficultyImpact = difficultyImpact ?? defaultDifficultyImpact,
            DueDate          = dueDate,
            CompletedAt      = completedAt,
            CreatedAtUtc     = now,
        };

        return todo;
    }
}
