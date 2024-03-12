using System.ComponentModel.DataAnnotations;
using Core.Data.Entity.Base;

namespace Core.Data.Entity.Default;

public class Role : BaseEntity<long>
{
    [Required, MaxLength(50)] public string Name { get; set; } = null!;
    [MaxLength(300)] public string? Description { get; set; }
    public bool IsStrict { get; init; }


    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}