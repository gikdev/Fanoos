using System.Data.Common;

namespace Fanoos.Common.Application.Data;

public interface IDbConnectionFactory {
    ValueTask<DbConnection> OpenConnectionAsync();
}
