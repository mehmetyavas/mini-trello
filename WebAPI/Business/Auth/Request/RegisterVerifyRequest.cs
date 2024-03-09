using System.ComponentModel.DataAnnotations;
using MediatR;
using IResult = Core.Utilities.Results.IResult;

namespace WebAPI.Business.Auth.Request;

public class RegisterVerifyRequest : IRequest<IResult>
{
    [Required] public string Token { get; set; } = null!;
}