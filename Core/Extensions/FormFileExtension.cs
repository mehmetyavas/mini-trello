using Core.Data.Enum;
using Microsoft.AspNetCore.Http;

namespace Core.Extensions;

public static class FormFileExtension
{
    // public static bool FileForComment(this IFormFile file)
    // {
    //     var acceptableExt = new[]
    //     {
    //         FileFormat.gif.ToString(),
    //         FileFormat.jpeg.ToString(),
    //         FileFormat.jpg.ToString(),
    //         FileFormat.png.ToString()
    //     };
    //     var fileExt = Path.GetExtension(file.FileName).Trim('.');
    //
    //     if (acceptableExt.Contains(fileExt))
    //         return true;
    //
    //     return false;
    // }
    //
    // public static bool FileForTodo(this IFormFile file)
    // {
    //     var acceptableExt = new[]
    //     {
    //         FileFormat.pdf.ToString(),
    //         FileFormat.jpeg.ToString(),
    //         FileFormat.jpg.ToString(),
    //         FileFormat.png.ToString()
    //     };
    //     var fileExt = Path.GetExtension(file.FileName).Trim('.');
    //
    //     if (acceptableExt.Contains(fileExt))
    //         return true;
    //
    //     return false;
    // }
}