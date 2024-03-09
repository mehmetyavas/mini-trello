using Core.Data.Entity.Base;

namespace Core.Data.Dto.Email;

public class MailCreds : IDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int Port { get; set; }
}