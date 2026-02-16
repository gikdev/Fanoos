using Fanoos.Domain.Todos;

namespace Fanoos.Application.Todos;

public interface ITodoRepository {
    Task             AddAsync(Todo todo, CancellationToken cancellationToken = default);
    Task<List<Todo>> ListAsync(CancellationToken cancellationToken = default);
}
