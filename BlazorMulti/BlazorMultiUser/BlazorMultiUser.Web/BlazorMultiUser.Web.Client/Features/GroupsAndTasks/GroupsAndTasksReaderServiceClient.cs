using System.Net.Http.Json;
using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;

namespace BlazorMultiUser.Web.Client.Features.GroupsAndTasks;

public class GroupsAndTasksReaderServiceClient(HttpClient httpClient) : ServiceCommonBase, IGroupsAndTasksReaderService
{
    public async Task<IEnumerable<GroupCoreDto>> GetAllGroups()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<GroupCoreDto>>(ApiEndpoints.GetAllGroups) ?? [];
    }
}