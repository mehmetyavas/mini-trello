using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;

namespace Core.Data.Entity.Default;

public class UserRole : BaseEntity
{
    [Required, ForeignKey(nameof(RoleId))] public long RoleId { get; set; }
    [Required, ForeignKey(nameof(UserId))] public Guid UserId { get; set; }


    public virtual Role Role { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}