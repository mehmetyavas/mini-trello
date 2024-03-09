using Core.Data.Entity.Base;

namespace Core.Data.Dto.File;

public class UploaderResponse : IDto
{
    public string Name { get; set; } = null!;
    public long Size { get; set; }
}