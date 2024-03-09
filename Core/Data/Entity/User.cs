using System.ComponentModel.DataAnnotations;
using Core.Attributes.CustomAttributes;
using Core.Data.Entity.Base;
using Core.Data.Enum;
using Core.Extensions;
using Unique = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Core.Data.Entity;

//TODO add address 
//TODO seperate user and userInfo
[Unique(nameof(Email), IsUnique = true)]
[Unique(nameof(MobilePhone), IsUnique = true)]
public class User : BaseEntity<Guid>
{
    [MinLength(2), MaxLength(80), Required]
    public string Fullname { get; set; } = null!;


    [MaxLength(80), EmailAddress, Required]
    public string Email { get; set; } = null!;

    [PhoneNumber, MaxLength(13)] public string? MobilePhone { get; set; }

    public Gender Gender { get; set; }
    public string? AvatarUrl { get; set; }
    public DateTime BirthDate { get; set; }


    [Required] public string VerifyToken { get; set; } = null!;

    public bool IsVerified { get; set; }
    public DateTime VerifiedAt { get; set; }
    public long LoginCode { get; set; }

    public DateTime LoginCodeExpiredAt { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

    public virtual ICollection<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();


    public List<long> Roles()
    {
        if (!UserRoles!.Any())
            return new List<long>();

        var roles = UserRoles!.Select(x => (x.RoleId));

        return roles.ToList();
    }

    public List<int> RoleIds()
    {
        if (!UserRoles!.Any())
            return new List<int>();

        var roles = UserRoles!.Select(x => ((int)x.RoleId));

        return roles.ToList();
    }

    public List<ActionName> Permissions()
    {
        var actionNames = new List<ActionName>();


        var actionClaims = UserRoles.Select(x => x.Role.RolePermissions);
        foreach (var actions in actionClaims)
        {
            foreach (var action in actions)
            {
                actionNames.Add(action.Action.Id);
            }
        }

        actionNames.AddRange(UserPermissions.Select(x => x.ActionName));


        return actionNames;
    }

    public bool IsAdmin()
    {
        if (!UserRoles!.Any())
            return false;

        return UserRoles!.Any(x => x.RoleId == (long)Enum.Roles.Admin);
    }

    public List<string> ActionIds()
    {
        var actionNames = new List<string>();

        if (!UserRoles.Any())
            return actionNames;


        var actionClaims = UserRoles.Select(x => x.Role.RolePermissions);
        foreach (var actions in actionClaims)
        {
            foreach (var action in actions)
            {
                actionNames.Add(action.Action.Id.GetValueString());
            }
        }

        return actionNames;
    }
}