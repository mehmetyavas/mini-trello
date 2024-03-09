using Core.Data.Dto.File;
using Core.Data.Enum;
using Core.Utilities.Results;
using IResult = Core.Utilities.Results.IResult;

namespace Core.Services.FileUploader;

public class FileUploader
{
    private string _uploadsFolder;


    public FileUploader()
    {
        _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

        if (!Directory.Exists(_uploadsFolder))
            Directory.CreateDirectory(_uploadsFolder);
    }

    public async Task<IResult<UploaderResponse>> SaveFileAsync(FileRequest fileRequest)
    {
        if (fileRequest.File == null! ||
            fileRequest.File.Length == 0)
            return new ErrorResult<UploaderResponse>("file is null");


        var combinedPath = Path.Combine(_uploadsFolder, fileRequest.FileDirectory.ToString());

        if (!File.Exists(combinedPath))
            Directory.CreateDirectory(combinedPath);


        _uploadsFolder = combinedPath;


        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(fileRequest.File.FileName)}";

        var filePath = Path.Combine(_uploadsFolder, fileName);

        await using var stream = new FileStream(filePath, FileMode.Create);
        await fileRequest.File.CopyToAsync(stream);


        return new SuccessResult<UploaderResponse>(new UploaderResponse
        {
            Name = fileName,
            Size = fileRequest.File.Length
        });
    }

    public async Task<IResult<List<UploaderResponse>>> SaveFileAsync(MultipleFileRequest fileRequest)
    {
        if (fileRequest.File.Count < 1)
            return new ErrorResult<List<UploaderResponse>>("file is null");


        var combinedPath = _uploadsFolder.Contains(fileRequest.FileDirectory.ToString())
            ? _uploadsFolder
            : Path.Combine(_uploadsFolder, fileRequest.FileDirectory.ToString());


        if (!File.Exists(combinedPath))
            Directory.CreateDirectory(combinedPath);

        _uploadsFolder = combinedPath;

        var fileResponse = new List<UploaderResponse>();

        foreach (var file in fileRequest.File)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var filePath = Path.Combine(_uploadsFolder, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);

            await stream.DisposeAsync();

            fileResponse.Add(new UploaderResponse
            {
                Name = fileName,
                Size = file.Length
            });
        }


        return new SuccessResult<List<UploaderResponse>>(data: fileResponse);
    }

    public async Task<IResult<UploaderResponse>> UpdateFileAsync(FileRequest fileRequest, string name)
    {
        if (fileRequest.File == null! ||
            fileRequest.File.Length == 0)
            return new ErrorResult<UploaderResponse>("file is null");


        var combinedPath = Path.Combine(_uploadsFolder, fileRequest.FileDirectory.ToString());

        if (!File.Exists(combinedPath))
            Directory.CreateDirectory(combinedPath);


        _uploadsFolder = combinedPath;


        var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(fileRequest.File.FileName)}";
        var filePath = Path.Combine(_uploadsFolder, newFileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
            await fileRequest.File.CopyToAsync(stream);

        //burayı düzelt

        if (!string.IsNullOrWhiteSpace(name))
            if (File.Exists(Path.Combine(_uploadsFolder, name)))
                File.Delete(Path.Combine(_uploadsFolder, name));


        return new SuccessResult<UploaderResponse>(new UploaderResponse
        {
            Name = newFileName,
            Size = fileRequest.File.Length
        });
    }

    public IResult DeleteFile(string name, FileDirectory directory)
    {
        var combinedPath = Path.Combine(_uploadsFolder, directory.ToString());


        _uploadsFolder = combinedPath;

        var splittedName = name;

        if (!string.IsNullOrWhiteSpace(name))
            if (File.Exists(Path.Combine(_uploadsFolder, splittedName)))
                File.Delete(Path.Combine(_uploadsFolder, splittedName));


        return new SuccessResult("Silindi!");
    }
}