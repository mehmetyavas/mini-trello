using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Entity.Default;
using Core.Data.Enum;

namespace Core.Data.Entity;

public class WorkSpaceMember : BaseEntity
{
    [Required, ForeignKey(nameof(WorkSpaceId))]
    public long WorkSpaceId { get; set; }

    [Required, ForeignKey(nameof(UserId))] public Guid UserId { get; set; }

    public MemberStatus MemberStatus { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual WorkSpace WorkSpace { get; set; } = null!;
}