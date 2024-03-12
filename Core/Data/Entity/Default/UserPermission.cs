using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Enum;

namespace Core.Data.Entity.Default;

public class UserPermission : BaseEntity
{
    public ActionName ActionName { get; set; }

    [Required, ForeignKey(nameof(UserId))] public Guid UserId { get; set; }


    public virtual User User { get; set; } = null!;
}