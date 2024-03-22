using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Web.Client.Infrastructure;

public class AppContextServiceClient : IAppContextService
{
    public bool IsServerSideRender => false;
}