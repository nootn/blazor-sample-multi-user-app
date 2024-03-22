using BlazorMultiUser.Shared.Features;

namespace BlazorMultiUser.Web.Client.Features;

public abstract class ServiceCommonBase : IServiceCommon
{
    public bool IsClientSide => true;
}