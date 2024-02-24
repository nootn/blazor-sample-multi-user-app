using System.ComponentModel.DataAnnotations;

namespace BlazorMultiUser.Shared.Validation;

public class ApplicationUserIdAttribute() : StringLengthAttribute(MaxLength)
{
    public const int MaxLength = 450; //Not sure why, but the template uses 450 for the max length of the user id
}