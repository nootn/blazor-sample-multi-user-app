using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Infrastructure;
using BlazorMultiUser.Web.Client.Features.GroupsAndTasks;

namespace BlazorMultiUser.Web.Client.Infrastructure.Ioc;

public static class SharedRegistrationExtensions
{
    public static void UseSharedClientSide(this IServiceCollection services)
    {
        services.AddSingleton<IClock, Clock>();
        services.AddScoped<IAppContextService, AppContextServiceClient>();
        services.AddScoped<IGroupsAndTasksReaderService, GroupsAndTasksReaderServiceClient>();
        services.AddScoped<IGroupsAndTasksWriterService, GroupsAndTasksWriterServiceClient>();
    }
}