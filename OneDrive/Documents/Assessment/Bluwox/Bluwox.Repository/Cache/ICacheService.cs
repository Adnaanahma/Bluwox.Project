namespace Bluwox.Repository.Cache
{
    public interface ICacheService
    {
        Task SetValue(string cacheKey, string cacheValue, long ttl = 86400);
        Task<string?> GetValue(string cacheKey, bool clearFromCache = false);
        Task RemoveItemFromCache(string cacheKey);
    }
}
