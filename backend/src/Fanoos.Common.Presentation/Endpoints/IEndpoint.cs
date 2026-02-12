using Microsoft.AspNetCore.Routing;

namespace Fanoos.Common.Presentation.Endpoints;

public interface IEndpoint {
    void MapEndpoint(IEndpointRouteBuilder app);
}
