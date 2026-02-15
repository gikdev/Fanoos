using Fanoos.Common.Domain;

namespace Fanoos.Common.Application.Exceptions;

public sealed class FanoosException : Exception {
    public FanoosException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException) {
        RequestName = requestName;
        Error       = error;
    }

    public string RequestName { get; }

    public Error? Error { get; }
}
