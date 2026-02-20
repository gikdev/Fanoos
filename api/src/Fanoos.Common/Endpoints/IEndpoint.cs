using Microsoft.AspNetCore.Routing;

namespace Fanoos.Common.Endpoints;

public interface IEndpoint {
    void MapEndpoint(IEndpointRouteBuilder app);
}
