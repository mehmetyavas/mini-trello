using System.ComponentModel.DataAnnotations;

namespace Core.Attributes.CustomAttributes;

public class MaxValueAttribute : ValidationAttribute
{
    private readonly int _maxValue;

    public MaxValueAttribute(int maxValue)
    {
        _maxValue = maxValue;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is byte val)
        {
            if (val > _maxValue)
            {
                return new ValidationResult($"{val}' Değeri {_maxValue}'den küçük   olmalıdır");
            }
        }

        return ValidationResult.Success;
    }
}