using Fanoos.Common.Domain;

namespace Fanoos.Modules.Main.Domain.Todos;

public class Todo : IAggregateRoot {
    public Guid Id { get; private init; }
    public string RawTitle { get; private set; }
    public string Title { get; private set; }
    public string? Context { get; private set; }
    public string? Project { get; private set; }
    public string? Time { get; private set; }
    public string? Tag { get; private set; }
    public string? Energy { get; private set; }
    public bool IsImportant { get; private set; }
    public bool IsUrgent { get; private set; }
    public bool IsDone { get; private set; }

    private Todo() { }

    public static Todo FromRaw(string raw) {
        var todo = new Todo { Id = Guid.NewGuid() };

        // Detect importance/urgency
        todo.IsImportant = raw.StartsWith("*") || raw.StartsWith("!*");
        todo.IsUrgent = raw.StartsWith("!*") || raw.StartsWith("!");

        // Remove leading markers
        raw = System.Text.RegularExpressions.Regex.Replace(raw, @"^(!?\*)\s*", "");

        // Extract fields
        todo.Context = ExtractSingle(raw, @"@(\S+)");
        todo.Time = ExtractSingle(raw, @"~(\S+)");
        todo.Tag = ExtractSingle(raw, @"#(\S+)");
        todo.Energy = ExtractSingle(raw, @"\$(\S+)");
        todo.Project = ExtractSingle(raw, @"\+(\S+)");

        // Clean title
        todo.Title = System.Text.RegularExpressions.Regex.Replace(raw, @"[@~#\$+]\S+", "").Trim();

        return todo;
    }

    private static string? ExtractSingle(string raw, string pattern) {
        var match = System.Text.RegularExpressions.Regex.Match(raw, pattern);
        return match.Success ? match.Groups[1].Value : null;
    }

    public string ToRawString() {
        var parts = new List<string>();

        if (IsUrgent && IsImportant) parts.Add("!*");
        else if (IsImportant) parts.Add("*");
        else if (IsUrgent) parts.Add("!");

        parts.Add(Title);

        if (!string.IsNullOrWhiteSpace(Context)) parts.Add($"@{Context}");
        if (!string.IsNullOrWhiteSpace(Time)) parts.Add($"~{Time}");
        if (!string.IsNullOrWhiteSpace(Tag)) parts.Add($"#{Tag}");
        if (!string.IsNullOrWhiteSpace(Energy)) parts.Add($"${Energy}");
        if (!string.IsNullOrWhiteSpace(Project)) parts.Add($"+{Project}");

        return string.Join(" ", parts);
    }
}
