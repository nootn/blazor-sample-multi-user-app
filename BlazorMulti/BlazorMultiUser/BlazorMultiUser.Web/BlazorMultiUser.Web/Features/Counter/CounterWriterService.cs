using BlazorMultiUser.Shared.Features.Counter;
using BlazorMultiUser.Shared.Features.Counter.Dto;
using BlazorMultiUser.Shared.Infrastructure;
using BlazorMultiUser.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorMultiUser.Web.Features.Counter;

public class CounterWriterService : ServiceCommonBase, ICounterWriterService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public CounterWriterService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<UserCountDto>> UpdateCounterForCurrentUser(UpdateCountRequest request)
    {
        var userClaimsPrincipal = _httpContextAccessor.HttpContext?.User;
        if (userClaimsPrincipal == null) return Result<UserCountDto>.CreateInvalidResult("User", "User not logged in");
        var user = await _userManager.GetUserAsync(userClaimsPrincipal);
        if (user == null) return Result<UserCountDto>.CreateInvalidResult("User", "User not configured");

        var existing = await _dbContext.UserCounts
            .Where(uc => uc.UserId == user.Id)
            .FirstOrDefaultAsync();
        if (existing == null)
        {
            existing = new UserCount
            {
                User = user,
                UserId = user.Id,
                Counter = 0,
                RowVersion = []
            };
            _dbContext.UserCounts.Add(existing);
        }
        else
        {
            existing.Counter = request.Counter;
        }

        await _dbContext.SaveChangesAsync();

        //add delay for demo purposes
        await Task.Delay(2000);

        return new UserCountDto(existing.Counter);
    }
}