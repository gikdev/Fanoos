using Fanoos.Common.Domain;
using MediatR;

namespace Fanoos.Common.Application.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
