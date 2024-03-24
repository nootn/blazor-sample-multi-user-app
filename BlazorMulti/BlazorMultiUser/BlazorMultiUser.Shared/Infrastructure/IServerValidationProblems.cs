namespace BlazorMultiUser.Shared.Infrastructure;

public interface IServerValidationProblems
{
    IDictionary<string, string[]> Errors { get; }
}