using Core.Extensions;
using Core.Utilities.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

namespace Core.Utilities.Security.Jwt;

public class TokenManager : ITokenManager
{
    private readonly IDistributedCache _cache;
    private readonly int _redisPort = 6379;

    public TokenManager(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task Deactivate(List<string> tokens)
    {
        await tokens.ForEachAsync(async token => await Deactivate((string)token));
    }

    public List<string> GetAll()
    {
        try
        {
#if !DEBUG
                var server = GetServer();
                return server.Keys().Select(x => (string)x).ToList();
#else
            return new List<string>();
#endif
        }
        catch (Exception)
        {
            Console.WriteLine(@"Redis Error - Get All Error");
            return new List<string>();
        }
    }

    public void Clear()
    {
        try
        {
            var server = GetServer();
            server.FlushDatabase();
        }
        catch (Exception)
        {
            Console.WriteLine(@"Redis Error - Clearance Error");
        }
    }

    public async Task ClearToken(string token)
    {
        await _cache.RemoveAsync(GetKey(token));
    }

    public async Task ClearTokens(List<string> tokens)
    {
#if !DEBUG
            await tokens.ForEachAsync(async token => await ClearToken(token));
#endif
    }

    public async Task<bool> IsActive(string token)
    {
        try
        {
#if !DEBUG
                return await _cache.GetStringAsync(GetKey(token)) == null;
#else
            return true;
#endif
        }
        catch (Exception)
        {
            Console.WriteLine($@"Redis Error - IsActive Check Failed - {token}");
            return true;
        }
    }

    public async Task Deactivate(string token)
    {
        try
        {
#if !DEBUG
            await _cache.SetStringAsync(GetKey(token),
                " ", new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromDays(AppConfig.Settings.DefaultRedisEntryExpiration)
                });
#endif
        }
        catch (Exception e)
        {
            Console.WriteLine($@"Redis Error - Deactive Failed - {token}");
        }
    }

    private static string GetKey(string token)
    {
        return $"tokens:{token}:deactivated";
    }

    private StackExchange.Redis.IServer GetServer()
    {
        try
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(AppConfig.ConnectionStringsCache.Redis);
            return connectionMultiplexer.GetServer(AppConfig.ConnectionStringsCache.Redis, _redisPort);
        }
        catch (Exception e)
        {
            Console.WriteLine(@"Redis Error - Get Server Failed");
            return null;
        }
    }
}