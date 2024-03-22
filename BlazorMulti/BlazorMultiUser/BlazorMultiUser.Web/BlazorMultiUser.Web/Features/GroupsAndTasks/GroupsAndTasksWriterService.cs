using System.Security.Claims;
using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;
using BlazorMultiUser.Shared.Infrastructure;
using BlazorMultiUser.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorMultiUser.Web.Features.GroupsAndTasks;

public class GroupsAndTasksWriterService : ServiceCommonBase, IGroupsAndTasksWriterService

{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GroupsAndTasksWriterService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<Result<CreateGroupRequest>> CreateGroup(CreateGroupRequest request)
    {
        var exists = await _dbContext.Groups.AnyAsync(g => g.Name == request.Name);
        if (exists)
        {
            return new Result<CreateGroupRequest>.Invalid(new Dictionary<string, string[]>
            {
                {nameof(CreateGroupRequest.Name), new[] {"Group with this name already exists"}}
            });
        }

        var userClaimsPrincipal = _httpContextAccessor.HttpContext?.User;
        var owner = userClaimsPrincipal == null ? null : await _userManager.GetUserAsync(userClaimsPrincipal);

        if (owner == null)
        {
            return new Result<CreateGroupRequest>.Invalid(new Dictionary<string, string[]>
            {
                {nameof(CreateGroupRequest.Name), new[] {"Not able to set owner"}}
            });
        }

        _dbContext.Groups.Add(new Group
        {
            Name = request.Name,
            Owner = owner,
            OwnerId = owner.Id
        });
        await _dbContext.SaveChangesAsync();

        return request;
    }
}