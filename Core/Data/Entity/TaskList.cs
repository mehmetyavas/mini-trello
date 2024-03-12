using Core.Data.Entity.Base;

namespace Core.Data.Entity;

public class TaskList : BaseEntity
{
    public string Title { get; set; } = null!;

    // değer aralığı 0-255
     
    public byte Order { get; set; }
}