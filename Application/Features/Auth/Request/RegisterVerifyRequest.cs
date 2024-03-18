using System.ComponentModel.DataAnnotations;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace Application.Features.Auth.Request;

public class RegisterVerifyRequest : IRequest<IResult>
{
    [Required] public string Token { get; set; } = null!;
}