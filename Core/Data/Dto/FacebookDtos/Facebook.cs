namespace Core.Data.Dto.FacebookDtos;

public class Facebook
{
    public Login Login { get; set; } = new();
    public Links Links { get; set; } = new();
}