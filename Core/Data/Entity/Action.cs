using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Enum;

namespace Core.Data.Entity;

public class Action : BaseEntity<ActionName>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public new ActionName Id { get; set; }

    [MaxLength(50)] [Required] public string ActionName { get; set; } = null!;
    public virtual ICollection<RolePermission>? ActionClaims { get; set; } = new List<RolePermission>();
}