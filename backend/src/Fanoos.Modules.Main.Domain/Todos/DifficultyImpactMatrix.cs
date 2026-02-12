using Fanoos.Common.Domain;

namespace Fanoos.Modules.Main.Domain.Todos;

public record DifficultyImpactMatrix {
    public bool IsDifficult { get; init; }
    public bool IsImpactful { get; init; }

    private DifficultyImpactMatrix() { }

    public static Result<DifficultyImpactMatrix> Create(bool isDifficult, bool isImpactful) {
        var difficultyImpactMatrix = new DifficultyImpactMatrix {
            IsDifficult = isDifficult,
            IsImpactful = isImpactful,
        };

        return difficultyImpactMatrix;
    }

    public static DifficultyImpactMatrix CreateDefault() {
        var difficultyImpactMatrix = new DifficultyImpactMatrix {
            IsDifficult = false,
            IsImpactful = false,
        };

        return difficultyImpactMatrix;
    }

    public DifficultyImpactAction Recommendation => (IsDifficult, IsImpactful) switch {
        (false, true)  => DifficultyImpactAction.DoNow,
        (true, true)   => DifficultyImpactAction.Schedule,
        (false, false) => DifficultyImpactAction.DoLater,
        (true, false)  => DifficultyImpactAction.Eliminate
    };
}
