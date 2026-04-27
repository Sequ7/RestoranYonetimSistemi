using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager(IMemoryCache cache) : ICacheManager
    {
        private readonly IMemoryCache _cache = cache ?? throw new ArgumentNullException(nameof(cache));

        public void Add(string key, object data, int duration)
        {
            _cache.Set(
                key,
                data,
                TimeSpan.FromMinutes(duration)
            );
        }

        public T? Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object ?Get(string key)
        {
            return _cache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
        public void RemoveByPattern(string pattern)
        {
            var entriesProperty = typeof(MemoryCache)
                .GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            if (entriesProperty?.GetValue(_cache) is not IEnumerable cacheEntries)
                return;

            var cacheEntriesList = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntries)
            {
                var valueProperty = cacheItem.GetType().GetProperty("Value");
                if (valueProperty?.GetValue(cacheItem) is ICacheEntry entry)
                {
                    cacheEntriesList.Add(entry);
                }
            }

            var regex = new Regex(
                pattern,
                RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var keysToRemove = cacheEntriesList
                .Where(e => regex.IsMatch(e.Key?.ToString() ?? string.Empty))
                .Select(e => e.Key)
                .ToList();

            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
        }
    }
}
