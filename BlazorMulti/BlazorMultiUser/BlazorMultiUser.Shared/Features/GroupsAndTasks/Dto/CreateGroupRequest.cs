using BlazorMultiUser.Shared.Validation;

namespace BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;

public class CreateGroupRequest
{
    [GroupName] public required string Name { get; set; }
}