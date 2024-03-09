using System.ComponentModel.DataAnnotations;
using Core.Data.Enum;
using Core.Extensions;

namespace Core.Attributes.CustomAttributes;

public class PositiveNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is decimal positive)
        {
            if (positive < 1)
                return new ValidationResult(LangKeys.ValueMustBePositive.Localize());
        }

        return ValidationResult.Success;
    }
}