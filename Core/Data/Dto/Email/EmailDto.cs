using System.ComponentModel.DataAnnotations;
using Core.Data.Entity.Base;

namespace Core.Data.Dto.Email;

public class EmailDto : IDto
{
    [Required, EmailAddress] public string Email { get; init; } = null!;

    [Required] public string Subject { get; set; } = null!;
    [Required] public string Body { get; set; } = null!;
}

public class EmailNotificationParameters
{
    public string[] SubjectParameters { get; set; } = Array.Empty<string>();
    public string[] BodyParameters { get; set; } = Array.Empty<string>();
    public string[] ActionTextParameters { get; set; } = Array.Empty<string>();
    public string[] ActionRedirectParameters { get; set; } = Array.Empty<string>();
}