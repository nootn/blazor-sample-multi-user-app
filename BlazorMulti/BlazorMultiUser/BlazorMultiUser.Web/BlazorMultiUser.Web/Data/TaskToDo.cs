using BlazorMultiUser.Shared.Validation;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace BlazorMultiUser.Web.Data;

public class TaskToDo
{
    public Guid TaskToDoId { get; set; }

    public required string Name { get; set; }

    public required string DescriptionMarkdown { get; set; }

    [ApplicationUserId]
    [PersonalData]
    [SuppressMessage("ReSharper", "EntityFramework.ModelValidation.UnlimitedStringLength")]
    public required string OwnerId { get; set; }

    public required ApplicationUser Owner { get; set; }

    public ICollection<ApplicationUser> Assignees { get; set; } = [];

    public ICollection<Group> Groups { get; set; } = [];
}