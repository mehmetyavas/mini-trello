namespace Core.Data.Dto.App;

public class TokenOptions
{
    public string Audience { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public int AccessExpiration { get; set; }
    public int RefreshExpiration { get; set; }
    public string Secret { get; set; } = null!;
}