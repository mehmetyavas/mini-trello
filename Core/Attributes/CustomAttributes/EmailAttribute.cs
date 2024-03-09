using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Core.Data.Enum;
using Core.Extensions;

namespace Core.Attributes.CustomAttributes;

public class EmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null ||
            string.IsNullOrWhiteSpace(value.ToString()))
            return ValidationResult.Success;

        if (value is string email)
        {
            var regex = new Regex(@"^\S+@\S+\.\S+$");
            if (!regex.IsMatch(email))
                return new ValidationResult($"{email} Email Gereksinimlerini Karşılamıyor!");
        }
        else if (value is List<string> emails)
        {
            var regex = new Regex(@"^\S+@\S+\.\S+$");
            foreach (var item in emails)
            {
                if (!regex.IsMatch(item))
                    return new ValidationResult($"{item} Email Gereksinimlerini Karşılamıyor!");
            }
        }
        else
        {
            return new ValidationResult(LangKeys.WrongParameter.Localize());
        }

        return ValidationResult.Success;
    }
}