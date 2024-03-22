namespace BlazorMultiUser.Shared.Infrastructure;

public class AppContextService : IAppContextService
{
    public bool IsServerSideRender => true;
}

public interface IAppContextService
{
    bool IsServerSideRender { get; }
}