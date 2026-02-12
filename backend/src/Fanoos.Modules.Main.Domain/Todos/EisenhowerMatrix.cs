using Fanoos.Common.Domain;

namespace Fanoos.Modules.Main.Domain.Todos;

public record EisenhowerMatrix {
    private EisenhowerMatrix() { }
    public bool IsUrgent    { get; init; }
    public bool IsImportant { get; init; }

    public EisenhowerAction Recommendation => (IsUrgent, IsImportant) switch {
        (true, true)   => EisenhowerAction.DoImmediately,
        (false, true)  => EisenhowerAction.Schedule,
        (true, false)  => EisenhowerAction.Delegate,
        (false, false) => EisenhowerAction.Delete
    };

    public static Result<EisenhowerMatrix> Create(bool isUrgent, bool isImportant) {
        var eisenhowerMatrix = new EisenhowerMatrix {
            IsImportant = isImportant,
            IsUrgent    = isUrgent
        };

        return eisenhowerMatrix;
    }

    public static EisenhowerMatrix CreateDefault() {
        var eisenhowerMatrix = new EisenhowerMatrix {
            IsImportant = false,
            IsUrgent    = false
        };

        return eisenhowerMatrix;
    }
}
