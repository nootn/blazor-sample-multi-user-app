using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;
using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Shared.Features.GroupsAndTasks;

/// <summary>
/// To keep things simple, we will put all our business logic in the service layer - we are not really demonstrating the best way to do this.
/// </summary>
public interface IGroupsAndTasksReaderService : IServiceCommon
{
    Task<Result<IEnumerable<GroupCoreDto>>> GetAllGroups();
}