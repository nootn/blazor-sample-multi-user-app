namespace BlazorMultiUser.Shared.Infrastructure;

public class Clock : IClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}

public interface IClock
{
    /// <summary>
    ///     Retrieves the current system time in UTC.
    /// </summary>
    DateTimeOffset UtcNow { get; }
}