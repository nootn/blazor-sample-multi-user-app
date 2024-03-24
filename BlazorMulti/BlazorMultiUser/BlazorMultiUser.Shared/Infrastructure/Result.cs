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


    public static Result<T> CreateSuccessResult(T item)
    {
        return new Success(item);
    }

    public static Result<T> CreateInvalidResult(string key, string message)
    {
        return new Invalid(new Dictionary<string, string[]> { { key, new[] { message } } });
    }
}