using Fanoos.Common.Domain;

namespace Fanoos.Common.Application.Authorization;

public interface IPermissionService {
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}
