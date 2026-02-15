using Fanoos.Application.Todos;
using Fanoos.Domain.Todos;
using Fanoos.Infrastructure.Database;

namespace Fanoos.Infrastructure.Todos;

public class TodoRepository(
    MainDbCtx db
) : ITodoRepository {
    public Task AddAsync(Todo todo, CancellationToken cancellationToken = default) {
        db.Todos.Add(todo);
        return Task.CompletedTask;
    }
}
