using NodaTime;

namespace Identities.Domain.Common;

internal static class Clock
{
    [ThreadStatic] private static Instant? _customNow;

    /// <summary>
    /// Now time
    /// </summary>
    public static Instant Now => _customNow ?? SystemClock.Instance.GetCurrentInstant();

    /// <summary>
    /// only for test purposes!
    /// </summary>    
    public static void Set(Instant customNow) => _customNow = customNow;

    /// <summary>
    /// only for test purposes!
    /// </summary>
    public static void Reset() => _customNow = null;
}