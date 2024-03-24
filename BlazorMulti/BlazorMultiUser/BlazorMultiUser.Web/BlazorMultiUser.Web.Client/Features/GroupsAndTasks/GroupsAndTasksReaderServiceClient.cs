using System.Net.Http.Json;
using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;
using BlazorMultiUser.Shared.Infrastructure;

namespace BlazorMultiUser.Web.Client.Features.GroupsAndTasks;

public class GroupsAndTasksReaderServiceClient(HttpClient httpClient) : ServiceCommonBase, IGroupsAndTasksReaderService
{
    public async Task<Result<IEnumerable<GroupCoreDto>>> GetAllGroups()
    {
        var res = await httpClient.GetFromJsonAsync<IEnumerable<GroupCoreDto>>(ApiEndpoints.GetAllGroups) ?? [];
        return Result<IEnumerable<GroupCoreDto>>.CreateSuccessResult(res);
    }
}