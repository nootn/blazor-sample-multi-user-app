using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Shared.Infrastructure;
using BlazorMultiUser.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorMultiUser.Web.Features.Counter;

public class CounterReaderService(
    ApplicationDbContext dbContext,
    UserManager<ApplicationUser> userManager,
    IHttpContextAccessor httpContextAccessor)
    : ServiceCommonBase, ICounterReaderService
{
    public async Task<Result<UserCountDto>> GetCounterForCurrentUser()
    {
        var userClaimsPrincipal = httpContextAccessor.HttpContext?.User;
        if (userClaimsPrincipal == null) return Result<UserCountDto>.CreateInvalidResult("User", "User not logged in");
        var user = await userManager.GetUserAsync(userClaimsPrincipal);
        if (user == null) return Result<UserCountDto>.CreateInvalidResult("User", "User not configured");

        var res = await dbContext.UserCounts
            .Where(uc => uc.UserId == user.Id)
            .Select(uc => new UserCountDto(uc.Counter))
            .FirstOrDefaultAsync();

        //add delay for demo purposes
        await Task.Delay(1000);

        return res ?? new UserCountDto(0);
    }
}