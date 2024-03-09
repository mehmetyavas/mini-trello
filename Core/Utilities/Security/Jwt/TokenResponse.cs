namespace Core.Utilities.Security.Jwt
{
    public class TokenResponse
    {
        public string AccessToken { get; set; } = null!;
        public DateTime AccessExpiration { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshExpiration { get; set; }
        public string? AvatarUrl { get; set; }
        public List<string> Roles { get; set; } = new();

        public List<int> Permissions { get; set; } = new();
    }
}