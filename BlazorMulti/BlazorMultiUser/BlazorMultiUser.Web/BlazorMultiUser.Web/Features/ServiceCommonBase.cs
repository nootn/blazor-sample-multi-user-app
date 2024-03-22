using BlazorMultiUser.Shared.Features;

namespace BlazorMultiUser.Web.Features;

public abstract class ServiceCommonBase : IServiceCommon
{
    public bool IsServerSide => true;
}