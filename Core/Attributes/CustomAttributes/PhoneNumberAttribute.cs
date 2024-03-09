using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Core.Data.Enum;
using Core.Extensions;

namespace Core.Attributes.CustomAttributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class PhoneNumberAttribute : ValidationAttribute
{
    protected override ValidationResult?
        IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
        {
            return ValidationResult.Success;
        }

        return Regex.IsMatch(value.ToString()!, "^(\\d{10})$")
            ? ValidationResult.Success
            : new ValidationResult(LangKeys.PhoneNumberValidation.Localize());
    }
}