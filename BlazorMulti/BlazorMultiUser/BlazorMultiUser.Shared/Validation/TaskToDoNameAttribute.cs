namespace BlazorMultiUser.Shared.Validation;

public class TaskToDoNameAttribute()
    : StringValidationBaseAttribute(MaxLength, @"^[a-zA-Z0-9\s-]*$",
        "can only contain letters, numbers, spaces and dashes (-)")
{
    public const int MaxLength = 100;
}