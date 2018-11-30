using Framework.Cashing;
using Microsoft.Extensions.Caching.Memory;
namespace Application.Utility
{
    public class CashMemory : ICashMemory
    {
        private readonly IMemoryCache _cache;
        public CashMemory(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void CashToken(string cashKey, object objectToCash)
        {
            _cache.Set(cashKey, objectToCash);
        }

        public object GetToken(string cashKey)
        {
            _cache.TryGetValue(cashKey, out object credentials);
            return credentials;
        }
    }
}
