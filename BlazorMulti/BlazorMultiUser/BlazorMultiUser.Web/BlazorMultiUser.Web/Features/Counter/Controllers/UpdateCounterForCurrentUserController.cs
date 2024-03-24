using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiUser.Web.Features.Counter.Controllers;

[Route(ApiEndpoints.UpdateCounterForCurrentUser)]
[ApiController]
public class UpdateCounterForCurrentUserController(ICounterWriterService counterWriterService) : Controller
{
    [HttpPost]
    public async Task<ActionResult<UserCountDto>> UpdateCounterForCurrentUser(UpdateCountRequest request)
    {
        return await counterWriterService.UpdateCounterForCurrentUser(request).ToWebResponse();
    }
}