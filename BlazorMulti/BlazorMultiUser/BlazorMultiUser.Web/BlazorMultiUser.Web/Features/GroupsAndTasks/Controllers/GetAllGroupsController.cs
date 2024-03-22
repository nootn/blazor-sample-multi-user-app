using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiUser.Web.Features.GroupsAndTasks.Controllers;

public class GetAllGroupsController(IGroupsAndTasksReaderService readerService) : Controller
{
    [HttpGet(ApiEndpoints.GetAllGroups)]
    public async Task<IEnumerable<GroupCoreDto>> GetAllGroups()
    {
        return await readerService.GetAllGroups();
    }
}