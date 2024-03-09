using System.Security.Claims;
using Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Core.Services;

public class UserResolverServices
{
    public Guid UserId { get; set; }

    public UserResolverServices(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext is not null)
        {
            var claim = httpContextAccessor.HttpContext.User;
            if (claim.Identity is not null &&
                claim.Identity.IsAuthenticated)
            {
                var id = claim.GetId();

                UserId = Guid.TryParse(id, out var guid) ? guid : Guid.Empty;
            }
        }
    }
}