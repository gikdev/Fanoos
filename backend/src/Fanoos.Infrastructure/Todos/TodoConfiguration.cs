using Fanoos.Domain.Todos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fanoos.Infrastructure.Todos;

internal sealed class TodoConfiguration : IEntityTypeConfiguration<Todo> {
    public void Configure(EntityTypeBuilder<Todo> builder) { }
}
