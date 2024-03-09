using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Enum;

namespace Core.Data.Entity;

public class RolePermission : BaseEntity
{
    [Required, ForeignKey(nameof(RoleId))] public long RoleId { get; set; }


    [Required, ForeignKey(nameof(ActionId))]
    public ActionName ActionId { get; set; }


    public virtual Role Role { get; set; } = null!;
    public virtual Action Action { get; set; } = null!;
}