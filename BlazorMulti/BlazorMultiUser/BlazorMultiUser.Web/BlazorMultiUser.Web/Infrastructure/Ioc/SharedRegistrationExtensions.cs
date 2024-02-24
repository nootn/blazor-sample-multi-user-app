using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Web.Infrastructure.Ioc;

public static class SharedRegistrationExtensions
{
    public static void UseSharedServerSide(this IServiceCollection services)
    {
        services.AddSingleton<IClock, Clock>();
    }
}