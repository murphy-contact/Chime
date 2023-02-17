using Chime.Shared.Abstractions.Time;

namespace Chime.Shared.Infrastructure.Time;

public class UtcClock : IClock
{
    public DateTime CurrentDate()
    {
        return DateTime.UtcNow;
    }
}