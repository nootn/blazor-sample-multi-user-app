using BlazorMultiUser.Shared;
using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMultiUser.Web.Features.Counter.Controllers;

[Route(ApiEndpoints.GetAllGetCounterForCurrentUser)]
[ApiController]
public class GetCounterForCurrentUserController(ICounterReaderService counterReaderService) : Controller
{
    [HttpGet]
    public async Task<ActionResult<UserCountDto>> GetCounterForCurrentUser()
    {
        return await counterReaderService.GetCounterForCurrentUser().ToWebResponse();
    }
}