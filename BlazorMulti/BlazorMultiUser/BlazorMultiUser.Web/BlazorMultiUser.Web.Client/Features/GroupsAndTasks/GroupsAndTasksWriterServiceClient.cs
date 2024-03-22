using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;
using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Web.Client.Features.GroupsAndTasks;

public class GroupsAndTasksWriterServiceClient : ServiceCommonBase, IGroupsAndTasksWriterService
{
    public Task<Result<CreateGroupRequest>> CreateGroup(CreateGroupRequest request)
    {
        throw new NotImplementedException();
    }
}