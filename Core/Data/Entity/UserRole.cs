using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Enum;

namespace Core.Data.Entity;

public class UserRole : BaseEntity
{
    [Required, ForeignKey(nameof(RoleId))] public long RoleId { get; set; }
    [Required, ForeignKey(nameof(UserId))] public Guid UserId { get; set; }


    public virtual Role Role { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}