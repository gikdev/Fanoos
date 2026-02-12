using Fanoos.Common.Application.Exceptions;
using Fanoos.Common.Infrastructure.Authentication;
using Fanoos.Modules.Main.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Fanoos.Modules.Main.Infrastructure.Authentication;

internal sealed class MainCtx(IHttpContextAccessor httpContextAccessor) : IMainCtx {
    public Guid UserId => httpContextAccessor.HttpContext?.User.GetUserId() ??
                          throw new FanoosException("User identifier is unavailable");
}
