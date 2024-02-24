using Microsoft.AspNetCore.Identity;

namespace BlazorMultiUser.Web.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public required ICollection<Group> OwnedGroups { get; set; }
    public required ICollection<Group> AssignedGroups { get; set; }
    public required ICollection<TaskToDo> OwnedTasks { get; set; }
    public required ICollection<TaskToDo> AssignedTasks { get; set; }
}