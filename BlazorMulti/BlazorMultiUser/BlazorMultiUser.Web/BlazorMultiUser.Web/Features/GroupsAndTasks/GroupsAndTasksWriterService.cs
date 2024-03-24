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
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<ApplicationUser> _userManager;

    public GroupsAndTasksWriterService(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Result<CreateGroupRequest>> CreateGroup(CreateGroupRequest request)
    {
        var exists = await _dbContext.Groups.AnyAsync(g => g.Name == request.Name);
        if (exists)
            return Result<CreateGroupRequest>.CreateInvalidResult(nameof(CreateGroupRequest.Name),
                "Group with this name already exists");

        var userClaimsPrincipal = _httpContextAccessor.HttpContext?.User;
        var owner = userClaimsPrincipal == null ? null : await _userManager.GetUserAsync(userClaimsPrincipal);

        if (owner == null)
            return Result<CreateGroupRequest>.CreateInvalidResult(nameof(CreateGroupRequest.Name),
                "Not able to set owner");

        _dbContext.Groups.Add(new Group
        {
            Name = request.Name,
            Owner = owner,
            OwnerId = owner.Id,
            RowVersion = []
        });
        await _dbContext.SaveChangesAsync();

        return request;
    }
}