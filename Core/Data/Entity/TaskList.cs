using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Data.Entity.Base;

namespace Core.Data.Entity;

public class TaskList : BaseEntity
{
    [Required, MinLength(3), MaxLength(25)]
    public string Title { get; set; } = null!;

    [MinLength(3), MaxLength(100)]
    public string Slug { get; set; } = null!;
    // değer aralığı 0-255

    public byte Order { get; set; }
    [ForeignKey(nameof(WorkSpaceId))] public long WorkSpaceId { get; set; }

    public virtual WorkSpace WorkSpace { get; set; } = null!;
}