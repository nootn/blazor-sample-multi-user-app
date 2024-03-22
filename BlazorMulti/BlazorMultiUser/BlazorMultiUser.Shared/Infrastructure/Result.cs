namespace BlazorMultiUser.Shared.Infrastructure;

public record Result<T>
{
    protected Result()
    {
    }

    public static implicit operator Result<T>(T value)
    {
        return new Success(value);
    }

    public record Success(T Value) : Result<T>;

    public record Invalid(Dictionary<string, string[]> Errors) : Result<T>;
}