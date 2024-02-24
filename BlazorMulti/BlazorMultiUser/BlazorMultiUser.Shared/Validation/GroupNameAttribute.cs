namespace BlazorMultiUser.Shared.Validation;

public class GroupNameAttribute()
    : StringValidationBaseAttribute(MaxLength, @"^[a-zA-Z0-9\s]*$", "can only contain letters, numbers, and spaces")
{
    public const int MaxLength = 50;
}