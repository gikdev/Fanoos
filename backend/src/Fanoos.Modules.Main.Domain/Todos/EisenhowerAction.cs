namespace Fanoos.Modules.Main.Domain.Todos;

/// <summary>
/// Actions based on the Eisenhower matrix (Urgency vs Importance).
/// </summary>
public enum EisenhowerAction {
    /// <summary>
    /// Urgent and Important — do it immediately.
    /// </summary>
    DoImmediately,

    /// <summary>
    /// Important but not urgent — schedule a time to do it.
    /// </summary>
    Schedule,

    /// <summary>
    /// Urgent but not important — delegate it to someone else.
    /// </summary>
    Delegate,

    /// <summary>
    /// Neither urgent nor important — delete or ignore.
    /// </summary>
    Delete
}
