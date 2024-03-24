using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Infrastructure;
using BlazorMultiUser.Web.Features.Counter;
using BlazorMultiUser.Web.Features.GroupsAndTasks;

namespace BlazorMultiUser.Web.Infrastructure.Ioc;

public static class SharedRegistrationExtensions
{
    public static void UseSharedServerSide(this IServiceCollection services)
    {
        services.AddSingleton<IClock, Clock>();
        services.AddScoped<IAppContextService, AppContextService>();
        services.AddScoped<ICounterReaderService, CounterReaderService>();
        services.AddScoped<ICounterWriterService, CounterWriterService>();
        services.AddScoped<IGroupsAndTasksReaderService, GroupsAndTasksReaderService>();
        services.AddScoped<IGroupsAndTasksWriterService, GroupsAndTasksWriterService>();
    }
}