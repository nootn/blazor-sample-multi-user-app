using BlazorMultiUser.Shared.Features.GroupsAndTasks;
using BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;
using BlazorMultiUser.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorMultiUser.Web.Features.GroupsAndTasks;

public class GroupsAndTasksReaderService(ApplicationDbContext dbContext)
    : ServiceCommonBase, IGroupsAndTasksReaderService
{
    public async Task<IEnumerable<GroupCoreDto>> GetAllGroups()
    {
        return await dbContext.Groups.Select(g => new GroupCoreDto
            {
                GroupId = g.GroupId,
                Name = g.Name
            }).OrderBy(g => g.Name).ToListAsync();
    }
}