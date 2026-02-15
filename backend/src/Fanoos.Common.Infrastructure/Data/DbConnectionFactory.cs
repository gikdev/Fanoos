using System.Data.Common;
using Fanoos.Common.Application.Data;
using Npgsql;

namespace Fanoos.Common.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory {
    public async ValueTask<DbConnection> OpenConnectionAsync() {
        return await dataSource.OpenConnectionAsync();
    }
}
