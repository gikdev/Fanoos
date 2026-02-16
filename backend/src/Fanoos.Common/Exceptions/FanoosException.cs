namespace Fanoos.Common.Exceptions;

public sealed class FanoosException : Exception {
    public FanoosException(string requestName, Exception? innerException = default)
        : base("Application exception", innerException) {
        RequestName = requestName;
    }

    public string RequestName { get; }
}
