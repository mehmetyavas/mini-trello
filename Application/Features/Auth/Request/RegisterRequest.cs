using System.ComponentModel.DataAnnotations;
using Core.Attributes;
using Core.Attributes.CustomAttributes;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Auth.Request;

public class RegisterRequest : IRequest<IResult>
{
    [Required, MinLength(2), MaxLength(20)]
    public string FullName { get; set; } = null!;

    [Required, MinLength(7), MaxLength(40), EmailAddress]
    public string Email { get; set; } = null!;

    [Password,MinLength(8),MaxLength(20)]
    public string? Password { get; set; }

    [Required, PhoneNumber] public string MobilPhones { get; set; } = null!;
}