using Fanoos.Common.Application.Clock;

namespace Fanoos.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}
