using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Core.Attributes.CustomAttributes;

public class ListMinLengthAttribute : ValidationAttribute
{
    private readonly int _minLength;

    public ListMinLengthAttribute(int minLength)
    {
        _minLength = minLength;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is IList list)
        {
            if (list.Count >= _minLength)
                return ValidationResult.Success;
        }


        return new ValidationResult($"{_minLength}' ten büyük olmalıdır");
    }
}