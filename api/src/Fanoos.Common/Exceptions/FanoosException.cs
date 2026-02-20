namespace Fanoos.Common.Exceptions;

public sealed class FanoosException(
    string requestName,
    Exception? innerException = default
) : Exception("Application exception", innerException) {
    public string RequestName { get; } = requestName;
}
