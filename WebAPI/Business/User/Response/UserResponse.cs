using Core.Data.Dto.User;

namespace WebAPI.Business.User.Response;

public class UserResponse : UserDto
{
    public string? MobilePhone { get; set; }
}