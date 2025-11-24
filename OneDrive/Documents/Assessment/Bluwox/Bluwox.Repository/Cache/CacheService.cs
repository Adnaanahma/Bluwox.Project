using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Bluwox.Repository.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetValue(string cacheKey, string cacheValue, long ttl = 86400)
        {
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(ttl));
            var encodedValue = Encoding.UTF8.GetBytes(cacheValue);
            await _cache.SetAsync(cacheKey, encodedValue, options);
        }

        public async Task<string?> GetValue(string cacheKey, bool clearFromCache = false)
        {
            var cachedData = await _cache.GetAsync(cacheKey);
            if (cachedData != null)
            {
                var value = Encoding.UTF8.GetString(cachedData);

                if (clearFromCache)
                {
                    await _cache.RemoveAsync(cacheKey);
                }

                return value;
            }

            return null;
        }

        public async Task RemoveItemFromCache(string cacheKey)
        {
            await _cache.RemoveAsync(cacheKey);
        }
    }
}
