using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Web.Client.Infrastructure.Ioc;

public static class SharedRegistrationExtensions
{
    public static void UseSharedClientSide(this IServiceCollection services)
    {
        services.AddSingleton<IClock, Clock>();
    }
}