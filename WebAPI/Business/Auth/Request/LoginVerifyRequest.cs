using System.ComponentModel.DataAnnotations;
using Core.Data.Dto.Auth;
using Core.Utilities.Results;
using MediatR;

namespace WebAPI.Business.Auth.Request;

public class LoginVerifyRequest : IRequest<IResult<AuthResponse>>
{
    [Required] public long LoginCode { get; set; }
    public bool RememberMe { get; set; }
    
    
    
}