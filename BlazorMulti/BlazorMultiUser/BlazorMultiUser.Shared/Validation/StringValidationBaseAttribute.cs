using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlazorMultiUser.Shared.Validation;

public abstract class StringValidationBaseAttribute(int maxLength, string regexPattern, string regexErrorMessageSuffix)
    : ValidationAttribute
{
    public virtual bool AllowNull { get; set; } = false;
    public virtual bool AllowEmpty { get; set; } = true;
    public virtual bool AllowWhitespaceOnly { get; set; } = false;

    public override bool IsValid(object? value)
    {
        if (value == null) return AllowNull;

        var strValue = value.ToString() ?? "";

        if (strValue.Length == 0) return AllowEmpty;

        if (strValue.Length > 0 && string.IsNullOrWhiteSpace(strValue)) return AllowWhitespaceOnly;

        if (strValue.Length > maxLength)
        {
            ErrorMessage = "{0} must be less than " + maxLength + " characters";
            return false;
        }

        if (!Regex.IsMatch(strValue, regexPattern))
        {
            ErrorMessage = "{0} " + regexErrorMessageSuffix;
            return false;
        }

        return true;
    }
}