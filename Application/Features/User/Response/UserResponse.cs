using Core.Data.Dto.User;

namespace Application.Features.User.Response;

public class UserResponse : UserDto
{
    public string? MobilePhone { get; set; }
}