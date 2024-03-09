using System.ComponentModel.DataAnnotations;
using Core.Data.Enum;
using Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace Core.Attributes.CustomAttributes;

public class AcceptableFileFormatAttribute : ValidationAttribute
{
    private List<FileFormat> Format { get; set; }

    public AcceptableFileFormatAttribute(params FileFormat[] format)
    {
        Format = format.ToList();
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile file)
        {
            return ValidationResult.Success;
        }


        var ext = Path.GetExtension(file.FileName).TrimStart('.').ToLower();
        
        if (Format.All(x => x.ToString().ToLower() != ext))
        {
            return new ValidationResult(LangKeys.InvalidFileFormat.Localize());
        }

        return ValidationResult.Success;
    }
}