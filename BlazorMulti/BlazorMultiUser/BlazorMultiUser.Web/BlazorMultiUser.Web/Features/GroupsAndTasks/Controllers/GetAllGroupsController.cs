using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;
using BlazorMultiUser.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiUser.Web.Features.GroupsAndTasks.Controllers;

[Route(ApiEndpoints.GetAllGroups)]
[ApiController]
public class GetAllGroupsController(IGroupsAndTasksReaderService readerService) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GroupCoreDto>>> GetAllGroups()
    {
        return await readerService.GetAllGroups().ToWebResponse();
    }
}