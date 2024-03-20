using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;
using Core.Data.Enum;

namespace Core.Data.Entity;

public class TaskCard : BaseEntity
{
    [Required, MinLength(2), MaxLength(20)]
    public string Title { get; set; } = null!;

    [MaxLength(400)]
    public string? Image { get; set; }

    [MinLength(3), MaxLength(100)] public string Slug { get; set; } = null!;

    [ForeignKey(nameof(TaskListId))] public long TaskListId { get; set; }

    public byte Order { get; set; }
    public TaskPriority Priority { get; set; }

    public virtual TaskList TaskList { get; set; } = null!;
}