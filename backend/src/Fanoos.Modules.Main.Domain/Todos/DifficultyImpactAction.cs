namespace Fanoos.Modules.Main.Domain.Todos;

/// <summary>
/// Actions based on the Difficulty / Impact matrix (Effort vs Impact).
/// </summary>
public enum DifficultyImpactAction {
    /// <summary>
    /// Low Effort, High Impact — "Quick Wins"; do it now.
    /// </summary>
    DoNow,

    /// <summary>
    /// High Effort, High Impact — "Big Projects"; schedule a time to do it.
    /// </summary>
    Schedule,

    /// <summary>
    /// Low Effort, Low Impact — "Filling Jobs"; do it later or when convenient.
    /// </summary>
    DoLater,

    /// <summary>
    /// High Effort, Low Impact — "Thankless Tasks"; better to eliminate.
    /// </summary>
    Eliminate
}
