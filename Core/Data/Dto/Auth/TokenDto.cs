using System.ComponentModel.DataAnnotations;

namespace Core.Data.Dto.Auth;

public class TokenDto
{
    [Required] public string AccessToken { get; set; } = null!;
    [Required] public string RefreshToken { get; set; } = null!;
}