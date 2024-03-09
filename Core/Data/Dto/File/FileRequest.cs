using Core.Attributes.CustomAttributes;
using Core.Data.Enum;
using Microsoft.AspNetCore.Http;

namespace Core.Data.Dto.File;

public class FileRequest
{
    [MaxFileSize((long)FileSize.Mb)]
    public IFormFile File { get; set; } = null!;
    public FileDirectory FileDirectory { get; set; } = FileDirectory.Avatar;
}

public class MultipleFileRequest
{
    [MaxFileSize((long)FileSize.Mb)]
    public List<IFormFile> File { get; set; } = null!;
    public FileDirectory FileDirectory { get; set; } = FileDirectory.Avatar;
}