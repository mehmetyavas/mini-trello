using Core.Data.Entity.Base;

namespace Core.Data.Dto.Email;

public class MailTemplateDto : IDto
{
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    public string ActionText { get; set; } = null!;
    public string ActionRedirect { get; set; } = null!;
    public string Email { get; set; } = null!;
}