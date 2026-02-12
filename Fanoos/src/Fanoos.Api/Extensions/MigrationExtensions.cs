using Microsoft.EntityFrameworkCore;
using Fanoos.Modules.Main.Infrastructure.Database;

namespace Fanoos.Api.Extensions;

internal static class MigrationExtensions {
    internal static void ApplyMigrations(this IApplicationBuilder app) {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<MainDbCtx>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope) where TDbContext : DbContext {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}
