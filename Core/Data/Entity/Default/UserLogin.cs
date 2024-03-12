using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Enum;

namespace Core.Data.Entity.Default;

public class UserLogin : BaseEntity<long>
{
    [ForeignKey(nameof(UserId))] public Guid UserId { get; set; }

    [Required] public string AccessToken { get; set; } = null!;

    [Required] public DateTime AccessTokenExpiresOn { get; set; }

    [Required] public DateTime RefreshTokenExpiresOn { get; set; }

    public string? RefreshToken { get; set; }

    public LoginProvider LoginProvider { get; set; }


    /// <summary>
    /// Account Id via Provider,
    /// </summary>
    public string ProviderKey { get; set; } = null!; 

    public User User { get; set; } = null!;
}