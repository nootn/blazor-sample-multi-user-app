using BlazorMultiUser.Shared.Validation;
using System.ComponentModel.DataAnnotations;

namespace BlazorMultiUser.Shared.Features.GroupsAndTasks.Dto;

public class GroupCoreDto
{
    public Guid? GroupId { get; set; }

    [GroupName]
    public required string Name { get; set; }
}