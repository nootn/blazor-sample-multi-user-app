using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using BlazorMultiUser.Shared.Validation;
using Microsoft.AspNetCore.Identity;

namespace BlazorMultiUser.Web.Data;

public class UserCount
{
    public Guid UserCountId { get; set; }

    [ApplicationUserId]
    [PersonalData]
    [SuppressMessage("ReSharper", "EntityFramework.ModelValidation.UnlimitedStringLength")]
    public required string UserId { get; set; }

    public required ApplicationUser User { get; set; }

    public int Counter { get; set; }

    [Timestamp]
    public required byte[] RowVersion { get; set; }
}