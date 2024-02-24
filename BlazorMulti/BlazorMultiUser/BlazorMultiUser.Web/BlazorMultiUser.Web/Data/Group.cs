using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BlazorMultiUser.Shared.Validation;
using Microsoft.AspNetCore.Identity;

namespace BlazorMultiUser.Web.Data;

public class Group
{
    public Guid GroupId { get; set; }

    //EF needs this because the other does not inherit from StringLengthAttribute
    [StringLength(GroupNameAttribute.MaxLength)]
    [GroupName]
    public required string Name { get; set; }

    [ApplicationUserId]
    [PersonalData]
    [SuppressMessage("ReSharper", "EntityFramework.ModelValidation.UnlimitedStringLength")]
    public required string OwnerId { get; set; }

    public required ApplicationUser Owner { get; set; }

    public ICollection<ApplicationUser> Assignees { get; set; } = [];

    public ICollection<TaskToDo> Tasks { get; set; } = [];
}