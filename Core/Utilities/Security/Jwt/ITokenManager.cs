namespace Core.Utilities.Security.Jwt;

public interface ITokenManager
{
    Task<bool> IsActive(string token);
    Task Deactivate(string token);
    Task Deactivate(List<string> tokens);
    Task ClearToken(string token);
    Task ClearTokens(List<string> tokens);
    List<string> GetAll();
    void Clear();
}