namespace Core.Data.Dto.ErrorModelStateDto;

public class ErrorModelState
{
    public string Key { get; set; } = null!;
    public List<ErrorModel>? Errors { get; set; } = new();
}