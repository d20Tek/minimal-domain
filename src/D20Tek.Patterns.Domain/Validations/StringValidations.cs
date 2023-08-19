//---------------------------------------------------------------------------------------------------------------------
// Copyright (c) d20Tek.  All rights reserved.
//---------------------------------------------------------------------------------------------------------------------
using System.Text.RegularExpressions;

namespace D20Tek.Patterns.Domain.Validations;

public static class StringValidations
{
    private const string _emailExpression = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";
    private const string _guidExpression = "^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$";
    private static TimeSpan _regexTimeout = TimeSpan.FromSeconds(2.0);
    private const RegexOptions _regexOptions = RegexOptions.Compiled |
                                               RegexOptions.IgnoreCase |
                                               RegexOptions.ExplicitCapture;

    public static bool NotEmpty(this string value) =>
        !string.IsNullOrEmpty(value);

    public static bool InMaxLength(this string value, int maxLen) =>
        value.Length <= maxLen;

    public static bool HasLength(this string value, int minLen, int maxLen) =>
        value.Length >= minLen && value.Length <= maxLen;

    public static bool IsValidEmailAddress(this string email) =>
        email.IsValidRegex(_emailExpression);

    public static bool IsGuidText(this string guid) =>
        guid.IsValidRegex(_guidExpression);

    public static bool IsValidRegex(this string text, string regexExpression)
    {
        if (string.IsNullOrEmpty(text)) return false;

        var regex = new Regex(regexExpression, _regexOptions, _regexTimeout);
        if (!regex.IsMatch(text))
        {
            return false;
        }

        return true;
    }
}
