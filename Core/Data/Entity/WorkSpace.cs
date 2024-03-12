using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Entity.Default;
using Core.Data.Enum;

namespace Core.Data.Entity;

public class WorkSpace : BaseEntity
{
    [Required, MinLength(3), MaxLength(20)]
    public string Title { get; set; } = null!;
    
    [ MinLength(3), MaxLength(70)]
    public string Slug { get; set; } = null!;

    [MaxLength(70)] public string? Description { get; set; }

    [ForeignKey(nameof(CreatorUserId))] public Guid CreatorUserId { get; set; }


    public virtual User CreatorUser { get; set; } = null!;


    public virtual ICollection<WorkSpaceMember> Members { get; set; } = new List<WorkSpaceMember>();
    public virtual ICollection<TaskList> TaskLists { get; set; } = new List<TaskList>();
}