using Fanoos.Common.Domain;

namespace Fanoos.Modules.Main.Domain.Todos;

public record TodoTitle {
    public string                      RawTitle { get; init; }
    public IReadOnlyCollection<string> Contexts { get; init; }
    public IReadOnlyCollection<string> Projects { get; init; }

    private TodoTitle() { }

    public static Result<TodoTitle> Create(string rawTitle) {
        string[] words = rawTitle.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var contexts = words.Where(w => w.StartsWith('@'))
            .Select(w => w[1..])
            .ToList();

        var projects = words.Where(w => w.StartsWith('+'))
            .Select(w => w[1..])
            .ToList();

        var todoTitle = new TodoTitle {
            Contexts = contexts,
            Projects = projects,
            RawTitle = rawTitle,
        };

        return todoTitle;
    }
}
