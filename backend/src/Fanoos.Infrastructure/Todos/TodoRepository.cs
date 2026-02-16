using Fanoos.Application.Todos;
using Fanoos.Domain.Todos;
using Fanoos.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Fanoos.Infrastructure.Todos;

public class TodoRepository(
    MainDbCtx db
) : ITodoRepository {
    public Task AddAsync(Todo todo, CancellationToken cancellationToken = default) {
        db.Todos.Add(todo);
        return Task.CompletedTask;
    }

    public async Task<List<Todo>> ListAsync(CancellationToken cancellationToken = default) {
        List<Todo> todos = await db.Todos.ToListAsync(cancellationToken: cancellationToken);
        return todos;
    }
}
